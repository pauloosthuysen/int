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

    }
}