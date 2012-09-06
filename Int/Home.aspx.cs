using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Text.RegularExpressions;

namespace Int
{
    public partial class Home : System.Web.UI.Page
    {

        private IntWebService1 ws;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["isLoggedIn"] == null)
            {
                Response.Redirect("Default.aspx");
            }

            ws = new IntWebService1();
            if (!IsPostBack)
            {
                User loggedInUser = (User)Session["loggedInUser"];
                lblUsername.Text = loggedInUser.Name;
                GridView1.DataSource = ws.GetProducts();
                GridView1.DataBind();
            }
            ShowCartGrid();
        }

        private void ShowCartGrid()
        {
            if (Session["Cart"] != null)
            {
                List<ShoppingCartItem> cartItems = new List<ShoppingCartItem>();
                decimal cartItemsTotalAmount = 0;
                foreach (var s in (List<string>)Session["Cart"])
                {
                    int pId = Int32.Parse(s.Split('|')[0]);
                    int pQu = Int32.Parse(s.Split('|')[1]);
                    Product prod = ws.GetProduct(pId);
                    decimal subTotal = (prod.Price * pQu);
                    cartItemsTotalAmount += subTotal;
                    cartItems.Add(new ShoppingCartItem(prod.Name, prod.Price, pQu, subTotal));
                }
                GridView2.DataSource = cartItems;
                GridView2.DataBind();
                Label1.Text = cartItemsTotalAmount.ToString("C"); ;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //get selected order products & quantity from GridView
            var products = GridView1.Rows.Cast<GridViewRow>()
                .Where(row => ((CheckBox)row.FindControl("AddToCart")).Checked)
                .Select(row => GridView1.DataKeys[row.RowIndex].Value.ToString() + "|" + ((ListBox)row.FindControl("ListBox1")).SelectedValue).ToList();

            if (Session["Cart"] == null) //if cart not exist, add GridView items
            {
                Session["Cart"] = (products.Count > 0) ? products : null;
            }
            else                        //else, add product & quantity to existing cart
            {
                var cart = (List<string>)Session["Cart"];
                foreach (var product in products) //if product exist in cart, only update quantity
                {
                    int nId = Int32.Parse(product.Split('|')[0]);
                    int nQu = Int32.Parse(product.Split('|')[1]);
                    bool valueExisted = false;
                    for(int i = 0; i < cart.Count; i++)
                    {
                        int cId = Int32.Parse(cart[i].Split('|')[0]);
                        if(cId == nId){
                            int cQu = Int32.Parse(cart[i].Split('|')[1]);
                            cart[i] = cId + "|" + (cQu + nQu).ToString();
                            valueExisted = true;
                        }
                    }
                    if(!valueExisted) //if product not exist in cart, add product & quantity from input
                    {
                        cart.Add(product);
                    }
                    Session["Cart"] = cart;
                }
            }

            //reset Checkboxes & Quantity fields
            foreach (GridViewRow row in GridView1.Rows)
            {
                CheckBox cb = (CheckBox)row.FindControl("AddToCart");
                ListBox lb = (ListBox)row.FindControl("ListBox1");
                if (cb.Checked)
                {
                    cb.Checked = false;
                }
                if (lb.SelectedValue != "1")
                {
                    lb.SelectedValue = "1";
                }
            }
            ShowCartGrid();
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            //clear session vars
            Session["isLoggedIn"] = null;
            Session["Cart"] = null;
            Session["loggedInUser"] = null;

            //redirect
            Response.Redirect("Default.aspx", true);
        }
    }
}