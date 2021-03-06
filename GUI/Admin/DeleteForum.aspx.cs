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
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using SD.HnD.BL;
using SD.HnD.DAL.EntityClasses;
using SD.HnD.Utility;

namespace SD.HnD.GUI.Admin
{
	/// <summary>
	/// Code behind file for the DeleteForum form.
	/// </summary>
	public partial class DeleteForum : System.Web.UI.Page
	{
		private int _forumID;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// If the user doesn't have any access rights to management stuff, the user should
			// be redirected to the default of the global system. 
            if (!SessionAdapter.HasSystemActionRights())
            {
				// doesn't have system rights. redirect.
				Response.Redirect("../Default.aspx",true);
			}

			// Check if the user has the right systemright;
			if (!SessionAdapter.HasSystemActionRight(ActionRights.SystemManagement))
			{
				// no, redirect to admin default page, since the user HAS access to the admin menu.
				Response.Redirect("Default.aspx",true);
			}

			_forumID = HnDGeneralUtils.TryConvertToInt(Request.QueryString["ForumID"]);

			if(!Page.IsPostBack)
			{

				// Get the forum
				try
				{
					ForumEntity forum = ForumGuiHelper.GetForum(_forumID);
					
					// Show results in the labels
					if(forum!=null)
					{
						// the forum exists
						lblForumName.Text = forum.ForumName;
						lblForumDescription.Text = forum.ForumDescription;
					}
					else
					{
						// the forum doesn't exist anymore
						Response.Redirect("ModifyDeleteForum.aspx",true);
					}
				}
				catch(Exception ex)
				{
					// Bubble
					throw ex;
				}
			}
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.btnDelete.ServerClick += new System.EventHandler(this.btnDelete_ServerClick);
			this.btnKeep.ServerClick += new System.EventHandler(this.btnKeep_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		private void btnDelete_ServerClick(object sender, System.EventArgs e)
		{
			// delete the forum.
			bool result = ForumManager.DeleteForum(_forumID);

			// invalidate cache
			CacheManager.InvalidateCachedItem(CacheManager.ProduceCacheKey(CacheKeys.SingleForum, _forumID));

			// Done
			Response.Redirect("ModifyDeleteForum.aspx",true);
		}


		private void btnKeep_ServerClick(object sender, System.EventArgs e)
		{
			// do nothing
			Response.Redirect("ModifyDeleteForum.aspx",true);
		}
	}
}
