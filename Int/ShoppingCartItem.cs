﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Int
{
    public class ShoppingCartItem
    {

        public ShoppingCartItem(int id, string name, decimal price, int quantity, decimal subTotal)
        {
            this.productId = id;
            this.name = name;
            this.price = price;
            this.quantity = quantity;
            this.subTotal = subTotal;
        }

        private int productId;
        private string name;
        private decimal price;
        private int quantity;
        private decimal subTotal;

        public int ProductId { get { return productId; } set { productId = value; } }
        public string Name { get { return name; } set { name = value; } }
        public decimal Price { get { return price; } set { price = value; } }
        public string PriceAsString { get { return price.ToString("C"); } }
        public int Quantity { get { return quantity; } set { quantity = value; } }
        public decimal SubTotal { get { return subTotal; } set { subTotal = value; } }
        public string SubTotalAsString { get { return subTotal.ToString("C"); } }
    }
}