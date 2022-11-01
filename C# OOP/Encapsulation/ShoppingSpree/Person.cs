using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    public class Person
    {
		private string name;
        private double money;
        public List<Product> Products;

        public Person(string name, double money)
		{
			Name = name;
			Money = money;
			Products = new List<Product>();

        }

        public string Name
		{
			get { return name; }
			set 
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new Exception("Name cannot be empty");
				}
				name = value; 
			}
		}
		public double Money
		{
			get { return money; }
			set 
			{
				if (value < 0)
				{
					throw new Exception("Money cannot be negative");
				}
				money = value; 
			}
		}
	}
}
