using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace Int
{
    public partial class Home : System.Web.UI.Page
    {

        private User loggedInUser;
        private IntWebService1 ws;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["isLoggedIn"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            if (!IsPostBack)
            {
                ws = new IntWebService1();
                loggedInUser = (User)Session["loggedInUser"];
                lblUsername.Text = loggedInUser.Name;
            }
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    LinkButton myBtn = (LinkButton)e.Row.Cells[4].Controls[0];
            //    myBtn.CommandArgument = e.Row.RowIndex.ToString();
            //}
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AddToCart")
            {
                int rowId = Int32.Parse(e.CommandArgument.ToString());
                GridView gv = (GridView)e.CommandSource;
                int pId = Int32.Parse(gv.Rows[rowId].Cells[0].Text);
                lblUsername.Text = pId.ToString() + "|" + ((ListBox)(gv.Rows[rowId].Cells[4].FindControl("ListBox1"))).SelectedValue;
            }
        }
    }
}