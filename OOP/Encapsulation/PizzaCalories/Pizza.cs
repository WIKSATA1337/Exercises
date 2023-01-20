﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace PizzaCalories
{
	public class Pizza
    {
		private string name;
        private Dough dough;
        private List<Topping> toppings;

		public Pizza(string name, Dough dough)
		{
			Name = name;
			Dough = dough;
			toppings = new List<Topping>();
		}

        public string Name
		{
			get { return name; }
            private set 
			{
				if (value.Length > 15 || value.Length < 1)
				{
					throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
				}
				name = value; 
			}
		}
		public Dough Dough
		{
			get { return dough; }
			private set { dough = value; }
		}

		public void AddTopping(Topping topping)
		{
			if (toppings.Count >= 10)
			{
				throw new ArgumentException("Number of toppings should be in range [0..10].");
			}

			toppings.Add(topping);
		}

        public double GetTotalCalories()
        {
            double doughCalories = Dough.GetCalories();
            double toppingsCalories = toppings.Sum(t => t.GetCalories());

            return doughCalories + toppingsCalories;
        }
    }
}