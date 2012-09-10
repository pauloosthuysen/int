using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Int
{
    public partial class ViewInvoice : System.Web.UI.Page
    {

        private User loggedInUser;
        private IntWebService1 ws;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["isLoggedIn"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            ws = new IntWebService1();
            loggedInUser = (User)Session["loggedInUser"];

            PopulateInvoice();
        }

        private void PopulateInvoice()
        {
            int orderId = Request.Params["id"] != null ? Int32.Parse(Request.Params["id"]) : 0;

            if (orderId == 0)
            {
                Response.Redirect("Home.aspx");
            }


            Order o = ws.GetOrder(orderId);
            if (o == null)
            {
                Response.Redirect("Home.aspx");
            }
            Invoice oi = ws.GetOrderInvoice(orderId);
            lblOrderDate.Text = o.Date.ToString("yyyy-MM-dd HH:mm:ss");
            lblInvoiceId.Text = oi.Id.ToString("D4");
            lblDiscount.Text = o.Discount.ToString("C");
            decimal totalAmount = 0;
            List<Product> orderProducts = ws.GetOrderProducts(orderId);
            foreach (var op in orderProducts)
            {
                totalAmount += op.Price * ws.GetOrderProductQuantity(orderId, op.Id);
            }
            lblTotalAmount.Text = totalAmount.ToString("C");
            totalAmount -= o.Discount;
            lblDueAmount.Text = totalAmount.ToString("C");
        }
    }
}