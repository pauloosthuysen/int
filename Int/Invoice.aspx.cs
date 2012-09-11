using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Int
{
    public partial class Invoice1 : System.Web.UI.Page
    {

        WebService1 ws;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["isLoggedIn"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            ws = new WebService1();
        }
    }
}