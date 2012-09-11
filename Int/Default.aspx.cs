using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Int
{
    public partial class Default : System.Web.UI.Page
    {
        WebService1 ws;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["isLoggedIn"] != null)
            {
                Response.Redirect("Home.aspx");
            }
            ws = new WebService1();
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            if (ws.AuthenticateUser(Login1.UserName, Login1.Password))
            {
                Session["isLoggedIn"] = 1;
                Session["user"] = ws.GetUser(Login1.UserName);
                Response.Redirect("Home.aspx");
            }
        }
    }
}