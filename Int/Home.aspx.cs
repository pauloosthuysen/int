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

        WebService1 ws;
        List<CartItem> cartItems;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["isLoggedIn"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            ws = new WebService1();

            if (!IsPostBack)
            {
                PopulateProductsGrid();
            }
            if (Session["cart"] != null)
            {
                PopulateCartItemsGrid();
            }
        }

        private void PopulateProductsGrid()
        {
            List<Product> products = ws.GetProducts();
            GridView1.DataSource = products;
            GridView1.DataBind();
        }

        private void PopulateCartItemsGrid()
        {
            var cart = (List<string>)Session["cart"];
            cartItems = new List<CartItem>();
            decimal tot = 0;
            cart.ForEach(it =>
            {
                int prodId = Int32.Parse(it.Split('|')[0]);
                int prodQu = Int32.Parse(it.Split('|')[1]);
                Product prod = ws.GetProduct(prodId);
                cartItems.Add(new CartItem() { Id = prodId, Name = prod.Name, Price = prod.Price, Quantity = prodQu, SubTotal = (prod.Price * prodQu) });
                tot += prod.Price * prodQu;
            });
            GridView2.DataSource = cartItems;
            GridView2.DataBind();
            lblCartItemsTotal.Text = tot.ToString("C");
        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            var selectedProducts = GridView1.Rows.Cast<GridViewRow>()
                .Where(row => ((CheckBox)row.FindControl("CheckBox1")).Checked)
                .Select(row => GridView1.DataKeys[row.RowIndex].Value.ToString() + "|" + ((ListBox)row.FindControl("ListBox1")).SelectedValue)
                .ToList();
            if (Session["cart"] == null)
            {
                Session["cart"] = selectedProducts;
            }
            else
            {
                var cart = (List<string>)Session["cart"];
                for (int i = 0; i < selectedProducts.Count; i++)
                {
                    int siId = Int32.Parse(selectedProducts[i].Split('|')[0]);
                    int siQu = Int32.Parse(selectedProducts[i].Split('|')[1]);
                    bool wasFound = false;
                    for (int k = 0; k < cart.Count; k++)
                    {
                        int ciId = Int32.Parse(cart[k].Split('|')[0]);
                        int ciQu = Int32.Parse(cart[k].Split('|')[1]);
                        if (siId == ciId)
                        {
                            wasFound = true;
                            cart[k] = ciId + "|" + (ciQu + siQu);
                        }
                    }
                    if (!wasFound)
                    {
                        cart.Add(selectedProducts[i]);
                    }
                }
            }
            GridView1.Rows.Cast<GridViewRow>().ToList().ForEach(it =>
            {
                CheckBox cb = (CheckBox)it.FindControl("CheckBox1");
                ListBox lb = (ListBox)it.FindControl("ListBox1");
                if (cb.Checked)
                {
                    cb.Checked = false;
                }
                if (lb.SelectedValue != "1")
                {
                    lb.SelectedValue = "1";
                }
            });

            PopulateCartItemsGrid();
        }

        protected void btnClearCart_Click(object sender, EventArgs e)
        {
            Session["cart"] = null;
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session["cart"] = null;
            Session["isLoggedIn"] = null;
            Session["user"] = null;
            Response.Redirect("Home.aspx");
        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            ws.AddOrder(((Int.User)Session["user"]).Id, cartItems);
            Session["cart"] = null;
            Response.Redirect("Invoice.aspx");
        }
    }
}