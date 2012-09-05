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

        private User loggedInUser;
        protected IntWebService1 ws;
        protected List<Product> products;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["isLoggedIn"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            ws = new IntWebService1();
            if (!IsPostBack)
            {
                loggedInUser = (User)Session["loggedInUser"];
                lblUsername.Text = loggedInUser.Name;
                products = ws.GetProducts();
                GridView1.DataSource = products;
                GridView1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var products = GridView1.Rows.Cast<GridViewRow>()
                .Where(row => ((CheckBox)row.FindControl("AddToCart")).Checked)
                .Select(row => GridView1.DataKeys[row.RowIndex].Value.ToString() + "|" + ((ListBox)row.FindControl("ListBox1")).SelectedValue).ToList();
            if (Session["Cart"] == null)
            {
                Session["Cart"] = products;
            }
            else
            {
                var cart = (List<string>)Session["Cart"];
                foreach (var product in products)
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
                    if(!valueExisted) //if exist, add quantity
                    {
                        cart.Add(product);
                    }
                    Session["Cart"] = cart;
                }
            }
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
        }
    }
}