using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Product
    {
        private string name;
        private decimal price;

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }

        public virtual decimal Price
        {
            get { return price; }
            set { price = value; }
        }
    }
}
