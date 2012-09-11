using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Int
{
    public class DataAccess
    {

        public static bool AuthenticateUser(string username, string password)
        {
            using (var cont = new DataAccessContainer())
            {
                var user = (from u in cont.Users
                            where u.Username == username && u.Password == password
                            select u).FirstOrDefault();
                return (user != null);
            }
        }

        public static User GetUser(string username)
        {
            using (var cont = new DataAccessContainer())
            {
                var user = (from u in cont.Users
                            where u.Username == username
                            select u).FirstOrDefault();
                return user;
            }
        }

        public static Product GetProduct(int productId)
        {
            using (var cont = new DataAccessContainer())
            {
                var product = (from p in cont.Products
                               where p.Id == productId
                               select p).FirstOrDefault();
                return product;
            }
        }

        public static List<Product> GetProducts()
        {
            using (var cont = new DataAccessContainer())
            {
                var products = (from p in cont.Products
                                select p).ToList();
                return products;
            }
        }

        public static Order GetOrder(int orderId)
        {
            using (DataAccessContainer cont = new DataAccessContainer())
            {
                return cont.Orders.FirstOrDefault(or => or.Id == orderId);
            }
        }

        public static Invoice GetOrderInvoice(int orderId)
        {
            using (DataAccessContainer cont = new DataAccessContainer())
            {
                return cont.Orders.FirstOrDefault(or => or.Id == orderId).Invoice;
            }
        }

        public static List<Product> GetOrderProducts(int orderId)
        {
            using (DataAccessContainer cont = new DataAccessContainer())
            {
                return cont.Orders.FirstOrDefault(or => or.Id == orderId).OrderProducts.Select(op => op.Product).ToList();
            }
        }

        public static int GetOrderProductQuantity(int orderId, int productId)
        {
            using (DataAccessContainer cont = new DataAccessContainer())
            {
                return cont.OrderProducts.Where(op => op.Product.Id == productId && op.Order.Id == orderId).Select(op => op.Quantity).FirstOrDefault();
            }
        }

        public static void AddOrder(int userId, List<CartItem> cartItems)
        {
            DataAccessContainer da = new DataAccessContainer();

            DateTime now = DateTime.Now;

            User usr = da.Users.FirstOrDefault(it=>it.Id == userId);
            Invoice nInvoice = new Invoice() { Date = now, IsPaid = false };
            Order nOrder = new Order() { Date = now, Discount = 0, Invoice = nInvoice};
            decimal tot = 0;
            cartItems.ForEach(it =>
            {
                Product p = da.Products.FirstOrDefault(pr=>pr.Id == it.Id);
                OrderProduct op = new OrderProduct() { Quantity = it.Quantity, Product = p, Order = nOrder };
                tot += p.Price * it.Quantity;
            });

            //calc Discount
            decimal discount = 0;
            if (tot >= 50)
            {
                discount += 10;
            }
            if(tot >= 75){
                discount += 10;
            }
            if (tot >= 100)
            {
                discount += 10;
            }
            nOrder.Discount = discount;

            usr.Orders.Add(nOrder);
            da.SaveChanges();
        }
    }
}