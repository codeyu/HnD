﻿///////////////////////////////////////////////////////////////
// This is generated code. 
//////////////////////////////////////////////////////////////
// Code is generated using LLBLGen Pro version: 2.6
// Code is generated on: 
// Code is generated using templates: SD.TemplateBindings.SharedTemplates.NET20
// Templates vendor: Solutions Design.
// Templates version: 
//////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Collections.Generic;
using SD.HnD.DAL;
using SD.HnD.DAL.FactoryClasses;
using SD.HnD.DAL.HelperClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace SD.HnD.DAL.RelationClasses
{
	/// <summary>Implements the static Relations variant for the entity: SupportQueue. </summary>
	public partial class SupportQueueRelations
	{
		/// <summary>CTor</summary>
		public SupportQueueRelations()
		{
		}

		/// <summary>Gets all relations of the SupportQueueEntity as a list of IEntityRelation objects.</summary>
		/// <returns>a list of IEntityRelation objects</returns>
		public virtual List<IEntityRelation> GetAllRelations()
		{
			List<IEntityRelation> toReturn = new List<IEntityRelation>();
			toReturn.Add(this.ForumEntityUsingDefaultSupportQueueID);
			toReturn.Add(this.SupportQueueThreadEntityUsingQueueID);


			return toReturn;
		}

		#region Class Property Declarations

		/// <summary>Returns a new IEntityRelation object, between SupportQueueEntity and ForumEntity over the 1:n relation they have, using the relation between the fields:
		/// SupportQueue.QueueID - Forum.DefaultSupportQueueID
		/// </summary>
		public virtual IEntityRelation ForumEntityUsingDefaultSupportQueueID
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "DefaultForForums" , true);
				relation.AddEntityFieldPair(SupportQueueFields.QueueID, ForumFields.DefaultSupportQueueID);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SupportQueueEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("ForumEntity", false);
				return relation;
			}
		}

		/// <summary>Returns a new IEntityRelation object, between SupportQueueEntity and SupportQueueThreadEntity over the 1:n relation they have, using the relation between the fields:
		/// SupportQueue.QueueID - SupportQueueThread.QueueID
		/// </summary>
		public virtual IEntityRelation SupportQueueThreadEntityUsingQueueID
		{
			get
			{
				IEntityRelation relation = new EntityRelation(SD.LLBLGen.Pro.ORMSupportClasses.RelationType.OneToMany, "SupportQueueThreads" , true);
				relation.AddEntityFieldPair(SupportQueueFields.QueueID, SupportQueueThreadFields.QueueID);
				relation.InheritanceInfoPkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SupportQueueEntity", true);
				relation.InheritanceInfoFkSideEntity = InheritanceInfoProviderSingleton.GetInstance().GetInheritanceInfo("SupportQueueThreadEntity", false);
				return relation;
			}
		}



		/// <summary>stub, not used in this entity, only for TargetPerEntity entities.</summary>
		public virtual IEntityRelation GetSubTypeRelation(string subTypeEntityName) { return null; }
		/// <summary>stub, not used in this entity, only for TargetPerEntity entities.</summary>
		public virtual IEntityRelation GetSuperTypeRelation() { return null;}

		#endregion

		#region Included Code

		#endregion
	}
}