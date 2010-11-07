/*
	This file is part of HnD.
	HnD is (c) 2002-2007 Solutions Design.
    http://www.llblgen.com
	http://www.sd.nl

	HnD is free software; you can redistribute it and/or modify
	it under the terms of version 2 of the GNU General Public License as published by
	the Free Software Foundation.

	HnD is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
	GNU General Public License for more details.

	You should have received a copy of the GNU General Public License
	along with HnD, please see the LICENSE.txt file; if not, write to the Free Software
	Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
*/
using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;

using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.HnD.DAL.CollectionClasses;
using SD.HnD.DAL.TypedListClasses;
using SD.HnD.DAL.FactoryClasses;
using SD.HnD.DAL;
using SD.HnD.DAL.HelperClasses;
using SD.HnD.DAL.EntityClasses;
using SD.HnD.DAL.DaoClasses;

namespace SD.HnD.BL
{
	/// <summary>
	/// Class to provide essential data for the Forum Gui
	/// </summary>
	public class ForumGuiHelper
    {
		/// <summary>
		/// Returns a TypedList which contains the last (amount) posted messages in
		/// the forum given. For RSS production.
		/// </summary>
		/// <param name="amount">limit of amount of messages to return</param>
		/// <param name="forumID">ID of forum to pull the messages for</param>
		/// <returns>typed list with data requested</returns>
		public static ForumMessagesTypedList GetLastPostedMessagesInForum(int amount, int forumID)
		{
			ForumMessagesTypedList forumMessages = new ForumMessagesTypedList();
			PredicateExpression filter = new PredicateExpression();
			filter.Add( (ForumFields.ForumID == forumID));
			filter.AddWithAnd((ForumFields.HasRSSFeed == true));
			SortExpression sorter = new SortExpression(MessageFields.PostingDate | SortOperator.Descending);
			forumMessages.Fill(amount, sorter, false, filter);

			return forumMessages;
		}

		
		/// <summary>
		/// Returns a DataView object that contains a complete list of threads list for
		/// the requested forum and required date & time interval
		/// </summary>
		/// <param name="forumID">ID of Forum for which the Threadlist is required</param>
		/// <param name="limiter">Limits the Threadlist to between now and; last 48 Hrs, Last Week, Last Month, Last Year</param>
		/// <param name="minNumberOfThreadsToFetch">The minimum number of threads to fetch if there are less threads available in the limiter interval</param>
		/// <param name="minNumberOfNonStickyVisibleThreads">The minimum number of non-sticky visible threads to show. If the # of threads is lower than 
		/// this number (due to the limiter value), the minNumberOfThreadsToFetch are fetched</param>
		/// <param name="canViewNormalThreadsStartedByOthers">If set to true, the user calling the method has the right to view threads started by others.
		/// Otherwise only the threads started by the user calling the method are returned.</param>
		/// <param name="userID">The userid of the user calling the method.</param>
		/// <returns>DataView with all the threads</returns>
		public static DataView GetAllThreadsInForumAsDataView(int forumID, ThreadListInterval limiter, short minNumberOfThreadsToFetch, 
				short minNumberOfNonStickyVisibleThreads, bool canViewNormalThreadsStartedByOthers, int userID)
		{
			DateTime limiterDate;

			// convert the limiter enum to a datetime which we can use in the filters on the thread data, where we'll use the limiter date
			// as a filter for the last posting date of a post in a given thread. 
            switch (limiter)
            {
				case ThreadListInterval.Last24Hours:
					limiterDate = DateTime.Today.AddHours(-24);
					break;
                case ThreadListInterval.Last48Hours:
					limiterDate = DateTime.Today.AddHours(-48);
                    break;
                case ThreadListInterval.LastWeek:
					limiterDate = DateTime.Today.AddDays(-7);
                    break;
                case ThreadListInterval.LastMonth:
					limiterDate = DateTime.Today.AddMonths(-1);
                    break;
                case ThreadListInterval.LastYear:
					limiterDate = DateTime.Today.AddYears(-1);
                    break;
				default:
					limiterDate = DateTime.Today.AddHours(-48);
					break;
            }

            // We'll use a dynamic list to retrieve all threads for the given forum in the right order, for the given limiter.
			ResultsetFields fields = ThreadGuiHelper.BuildDynamicListForAllThreadsWithStats();

			// now build the relations for the dynamic list. We'll join User twice: once for the startuser and one for the lastpost user. 
			// also, we'll join the last message to the thread. The last message is joined with a custom filter added to the relation. 
			RelationCollection relations = ThreadGuiHelper.BuildRelationsForAllThreadsWithStats();

            // Set up query conditions using Predicate Expressions
			// we'll keep the sticky threads filter and the forum filter in separate variables as we'll re-use them later on.
			FieldCompareValuePredicate stickyThreadsFilter = (FieldCompareValuePredicate)(ThreadFields.IsSticky == true);
			FieldCompareValuePredicate forumFilter = (FieldCompareValuePredicate)(ThreadFields.ForumID == forumID);

			PredicateExpression filter = new PredicateExpression();
			filter.Add(forumFilter);
			// combine the following two predicates into one predicate expression, as either one of them has to be true, but as a whole combined they should
			// act as a single operator to the AND operator with the forumfilter.
			PredicateExpression messageLimiterSubFilter = new PredicateExpression();
			messageLimiterSubFilter.Add(stickyThreadsFilter);
			messageLimiterSubFilter.AddWithOr(ThreadFields.ThreadLastPostingDate >= limiterDate);
			filter.AddWithAnd(messageLimiterSubFilter);

			// if the user can't view threads started by others, filter out threads started by users different from userID
			if(!canViewNormalThreadsStartedByOthers)
			{
				// caller can't view threads started by others: add a filter so that threads not started by calling user aren't enlisted. 
				// however sticky threads are always returned so the filter contains a check so the limit is only applied on threads which aren't sticky
				PredicateExpression threadsByOthersFilter = new PredicateExpression();
				threadsByOthersFilter.Add(ThreadFields.StartedByUserID==userID);
				// add a filter for sticky threads, add it with 'OR', so sticky threads are always accepted
				threadsByOthersFilter.AddWithOr(ThreadFields.IsSticky == true);
				filter.AddWithAnd(threadsByOthersFilter);
			}
            
            //Set up the sort expressions
            SortExpression sorter = new SortExpression(ThreadFields.IsSticky | SortOperator.Descending);
            sorter.Add(ThreadFields.IsClosed | SortOperator.Ascending);
            sorter.Add(ThreadFields.ThreadLastPostingDate | SortOperator.Descending);

			DataTable threads = new DataTable();
			TypedListDAO dao = new TypedListDAO();
            
            // Get the data by fetching the dynamic list into the datatable using the filter and the sorter we just setup.
			dao.GetMultiAsDataTable(fields, threads, 0, sorter, filter, relations, true, null, null, 0, 0);
         
			// count # non-sticky threads. If it's below a given minimum, refetch everything, but now don't fetch on date filtered but at least the
			// set minimum. Do this ONLY if the user can view other user's threads. If that's NOT the case, don't refetch anything.
			DataView stickyThreads = new DataView(threads, ThreadFieldIndex.IsSticky.ToString() + "=false", "", DataViewRowState.CurrentRows);
			if((stickyThreads.Count < minNumberOfNonStickyVisibleThreads) && canViewNormalThreadsStartedByOthers)
			{
				// not enough threads available, fetch again, 
				threads = new DataTable();

				// first fetch the sticky threads. 
				filter = new PredicateExpression();
				filter.Add(forumFilter);
				filter.AddWithAnd(stickyThreadsFilter);
                sorter = new SortExpression(ThreadFields.ThreadLastPostingDate | SortOperator.Descending);
				dao.GetMultiAsDataTable(fields, threads, 0, sorter, filter, relations, true, null, null, 0, 0);

				// then fetch the rest. Fetch it into the same datatable object to append the rows to the already fetched sticky threads (if any)
				stickyThreadsFilter.Value=false;
				dao.GetMultiAsDataTable(fields, threads, minNumberOfThreadsToFetch, sorter, filter, relations, true, null, null, 0, 0);

				// sort closed threads to the bottom. 
				return new DataView(threads, string.Empty, ThreadFieldIndex.IsClosed.ToString() + " ASC", DataViewRowState.CurrentRows);
			}
			else
			{
				return threads.DefaultView;
			}
		}


		/// <summary>
		/// Gets all forum data with section name in a typedlist. Sorted on Section.OrderNo, Section.SectionName, Forum.OrderNo, Forum.ForumName.
		/// </summary>
		/// <returns>Filled typedlist with all forum names / forumIDs and their containing section's name, sorted on Sectionname, and then forumname</returns>
		public static ForumsWithSectionNameTypedList GetAllForumsWithSectionNames()
		{
			ForumsWithSectionNameTypedList toReturn = new ForumsWithSectionNameTypedList();
			SortExpression sorter = new SortExpression();
			sorter.Add(SectionFields.OrderNo | SortOperator.Ascending);
			sorter.Add(SectionFields.SectionName | SortOperator.Ascending);
			sorter.Add(ForumFields.OrderNo| SortOperator.Ascending);
			sorter.Add(ForumFields.ForumName | SortOperator.Ascending);

			toReturn.Fill(0, sorter);

			return toReturn;
		}


		/// <summary>
		/// Gets all forum entities which belong to a given section. 
		/// </summary>
		/// <param name="sectionID">The section ID from which forums should be retrieved</param>
		/// <returns>Entity collection with entities for all forums in this section sorted alphabitacally</returns>
		public static ForumCollection GetAllForumsInSection(int sectionID)
		{
			//create the filter with the ID passed to the method.
			PredicateExpression filter = new PredicateExpression(ForumFields.SectionID == sectionID);

			// Sort forums on orderno ascending, then on name alphabetically
			SortExpression sorter = new SortExpression(ForumFields.OrderNo | SortOperator.Ascending);
			sorter.Add(ForumFields.ForumName | SortOperator.Ascending);

			ForumCollection toReturn = new ForumCollection();
			toReturn.GetMulti(filter, 0, sorter);
			return toReturn;
		}


		/// <summary>
		/// Retrieves for all available sections all forums with all relevant statistical information. This information is stored per forum in a
		/// DataView which is stored in the returned Dictionary, with the SectionID where the forum is located in as Key.
		/// </summary>
		/// <param name="availableSections">SectionCollection with all available sections</param>
		/// <param name="accessableForums">List of accessable forums IDs.</param>
		/// <param name="forumsWithOnlyOwnThreads">The forums for which the calling user can view other users' threads. Can be null</param>
		/// <param name="userID">The userid of the calling user.</param>
		/// <returns>
		/// Dictionary with per key (sectionID) a dataview with forum information of all the forums in that section.
		/// </returns>
		/// <remarks>Uses dataviews because a dynamic list is executed to retrieve the information for the forums, which include aggregate info about
		/// # of posts.</remarks>
        public static Dictionary<int, DataView> GetAllAvailableForumsDataViews(SectionCollection availableSections, List<int> accessableForums,
				List<int> forumsWithThreadsFromOthers, int userID)
        {
			Dictionary<int, DataView> toReturn = new Dictionary<int, DataView>();

            // return an empty list, if the user does not have a valid list of forums to access
            if (accessableForums == null || accessableForums.Count <= 0)
            {
                return toReturn;
            }

			// fetch all forums with statistics in a dynamic list, while filtering on the list of accessable forums for this user. 
			// Also filter on the threads viewable by the passed in userid, which is the caller of the method. If a forum isn't in the list of
			// forumsWithThreadsFromOthers, only the sticky threads and the threads started by userid should be counted / taken into account. 
			PredicateExpression threadFilter = new PredicateExpression();
			if((forumsWithThreadsFromOthers!=null) && (forumsWithThreadsFromOthers.Count > 0))
			{
				PredicateExpression onlyOwnThreadsFilter = new PredicateExpression();

				// accept only those threads who aren't in the forumsWithThreadsFromOthers list and which are either started by userID or sticky.
				// the filter on the threads not in the forums listed in the forumsWithThreadsFromOthers
				if(forumsWithThreadsFromOthers.Count == 1)
				{
					// optimization, specify the only value instead of the range, so we won't get a WHERE Field IN (@param) query which is slow on some
					// databases, but we'll get a WHERE Field == @param
					// accept all threads which are in a forum located in the forumsWithThreadsFromOthers list 
					threadFilter.Add((ThreadFields.ForumID == forumsWithThreadsFromOthers[0]));
					onlyOwnThreadsFilter.Add(ThreadFields.ForumID != forumsWithThreadsFromOthers[0]);
				}
				else
				{
					// accept all threads which are in a forum located in the forumsWithThreadsFromOthers list 
					threadFilter.Add((ThreadFields.ForumID == forumsWithThreadsFromOthers));
					onlyOwnThreadsFilter.Add(ThreadFields.ForumID != forumsWithThreadsFromOthers);
				}
				// the filter on either sticky or threads started by the calling user
				onlyOwnThreadsFilter.AddWithAnd(new PredicateExpression(ThreadFields.IsSticky == true)
						.AddWithOr(ThreadFields.StartedByUserID==userID));
				threadFilter.AddWithOr(onlyOwnThreadsFilter);
			}
			else
			{
				// there are no forums enlisted in which the user has the right to view threads from others. So just filter on
				// sticky threads or threads started by the calling user.
				threadFilter.Add(new PredicateExpression(ThreadFields.IsSticky == true)
						.AddWithOr(ThreadFields.StartedByUserID == userID));
			}
			ResultsetFields fields = new ResultsetFields(8);
			fields.DefineField(ForumFields.ForumID, 0);
			fields.DefineField(ForumFields.ForumName, 1);
			fields.DefineField(ForumFields.ForumDescription, 2);
			fields.DefineField(ForumFields.ForumLastPostingDate, 3);
			// add a scalar query which retrieves the # of threads in the specific forum. Utilizes an index on the FK field to forum in thread
			// this will result in the query:
			// (
			//		SELECT COUNT(ThreadID) FROM Thread 
			//		WHERE ForumID = Forum.ForumID AND threadfilter. 
			// ) As AmountThreads
			fields.DefineField(new EntityField("AmountThreads",
					new ScalarQueryExpression(ThreadFields.ThreadID.SetAggregateFunction(AggregateFunction.Count),
						new PredicateExpression(ThreadFields.ForumID == ForumFields.ForumID).AddWithAnd(threadFilter))), 4);

			// add a scalar query which retrieves the # of messages in the threads of this forum. Utilizies an index on the FK field in thread to forum.
			// this will result in the query:
			// (
			//		SELECT COUNT(MessageID) FROM Message 
			//		WHERE ThreadID IN
			//		(
			//			SELECT ThreadID FROM Thread WHERE ForumID = Forum.ForumID AND threadfilter
			//		)
			// ) AS AmountMessages
			fields.DefineField(new EntityField("AmountMessages",
					new ScalarQueryExpression(MessageFields.MessageID.SetAggregateFunction(AggregateFunction.Count),
						new FieldCompareSetPredicate(
								MessageFields.ThreadID,		// field to compare with the results in the IN clause
								ThreadFields.ThreadID,		// field to select in the select inside the IN clause
								SetOperator.In,				// operator, 
								new PredicateExpression(ThreadFields.ForumID == ForumFields.ForumID).AddWithAnd(threadFilter)	// the filter for the subquery inside the IN clause
								))), 5);	// rest of the DefineField method.
			
			fields.DefineField(ForumFields.HasRSSFeed, 6);
			fields.DefineField(ForumFields.SectionID, 7);

			DataTable results = new DataTable();
			TypedListDAO dao = new TypedListDAO();

			// sort per section: orderno and name, then per forum: orderno and name, so the views are already sorted automatically.
			SortExpression sorter = new SortExpression();
			sorter.Add(ForumFields.OrderNo | SortOperator.Ascending);
			sorter.Add(ForumFields.ForumName | SortOperator.Ascending);

			// use a field compare range predicate to filter on the forums accessable to the user
			dao.GetMultiAsDataTable(fields, results, 0, sorter, (ForumFields.ForumID == accessableForums), null, true, null, null, 0, 0);

            // Now per section create a new DataView in memory using in-memory filtering on the DataTable. 
            foreach(SectionEntity section in availableSections)
            {
                // Create view for current section and filter out rows we don't want. Do this with in-memory filtering of the dataview, so we don't
				// have to execute multiple queries. 
                DataView forumsInSection = new DataView(results, "SectionID=" + section.SectionID, string.Empty, DataViewRowState.CurrentRows);
                // add to sorted list with SectionID as key
                toReturn.Add(section.SectionID, forumsInSection);
            }

            // return the dictionary
            return toReturn;
        }


		/// <summary>
		/// Returns a ForumEntity of the given forum
		/// </summary>
		/// <param name="forumID">ForumID of forum which data should be read</param>
		/// <returns>forum entity with the data requested, or null if not found</returns>
		public static ForumEntity GetForum(int forumID)
		{
			ForumEntity toReturn = new ForumEntity(forumID);
			if(toReturn.Fields.State!=EntityState.Fetched)
			{
				return null;
			}
			return toReturn;
		}
	}
}