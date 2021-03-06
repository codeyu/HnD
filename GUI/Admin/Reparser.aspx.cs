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
using SD.HnD.Utility;

namespace SD.HnD.GUI.Admin
{
	/// <summary>
	/// Code behind file for the form to reparse all messages or an interval of messages. 
	/// </summary>
	public partial class Reparser : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			// If the user doesn't have any access rights to management stuff, the user should
			// be redirected to the default of the global system. 
			if(!SessionAdapter.HasSystemActionRights())
			{
				// doesn't have system rights. redirect.
				Response.Redirect("../Default.aspx", true);
			}

			// Check if the user has the right systemright
			bool hasAccess = SessionAdapter.HasSystemActionRight(ActionRights.SystemManagement);
			if(!hasAccess)
			{
				// no, redirect to admin default page, since the user HAS access to the admin menu.
				Response.Redirect("Default.aspx", true);
			}

			if(!Page.IsPostBack)
			{
				cldStartDate.SelectedDate = DateTime.Now;
				cldStartDate.VisibleDate = DateTime.Now;
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
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnStart_Click(object sender, System.EventArgs e)
		{
			// start the indexation. Grab the selected properties for the indexer.

			int amountToReparse = HnDGeneralUtils.TryConvertToInt(tbxAmountToReparse.Text.Trim());

			DateTime startDate = cldStartDate.SelectedDate;
			int amountProcessed = MessageManager.ReParseMessages(amountToReparse, startDate, chkRegenerateHTML.Checked, ApplicationAdapter.GetParserData());

			pnlReparseResults.Visible=true;
			lblReparseResults.Text = "Number of messages re-parsed: " + amountProcessed;
		}

	}
}
