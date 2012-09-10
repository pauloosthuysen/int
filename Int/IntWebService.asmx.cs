using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Int
{
    /// <summary>
    /// Summary description for IntWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class IntWebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public bool AuthenticateUser(string username, string password)
        {
            return DataAccess.AuthenticateUser(username, password);
        }

        [WebMethod]
        public User GetUser(string username)
        {
            return DataAccess.GetUser(username);
        }

        [WebMethod]
        public List<Product> GetProducts()
        {
            return DataAccess.GetProducts();
        }

        [WebMethod]
        public Product GetProduct(int productId)
        {
            return DataAccess.GetProduct(productId);
        }

        [WebMethod]
        public Order GetOrder(int orderId)
        {
            return DataAccess.GetOrder(orderId);
        }

        [WebMethod]
        public Invoice GetOrderInvoice(int orderId)
        {
            return DataAccess.GetOrderInvoice(orderId);
        }

        [WebMethod]
        public List<Product> GetOrderProducts(int orderId)
        {
            return DataAccess.GetOrderProducts(orderId);
        }

        [WebMethod]
        public int GetOrderProductQuantity(int orderId, int productId)
        {
            return DataAccess.GetOrderProductQuantity(orderId, productId);
        }
    }
}
