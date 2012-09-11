using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Int
{
    public class CartItem
    {

        private int id;
        private string name;
        private decimal price;
        private int quantity;
        private decimal subTotal;

        public int Id { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public decimal Price { get { return price; } set { price = value; } }
        public string PriceAsString { get { return price.ToString("C"); } }
        public int Quantity { get { return quantity; } set { quantity = value; } }
        public decimal SubTotal { get { return subTotal; } set { subTotal = value; } }
        public string SubTotalAsString { get { return this.subTotal.ToString("C"); } }

    }
}