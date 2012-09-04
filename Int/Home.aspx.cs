using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Int
{
    public partial class Home : System.Web.UI.Page
    {

        private User loggedInUser;
        private IntWebService1 ws = new IntWebService1();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["isLoggedIn"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            if (!IsPostBack)
            {
                loggedInUser = (User)Session["loggedInUser"];
            }
            lblUsername.Text = loggedInUser.Name;
        }
    }
}