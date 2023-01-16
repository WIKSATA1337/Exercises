using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Restaurant.Beverage;

namespace Restaurant.Beverage.Beverages
{
    public class Coffee : HotBeverage
    {
        private const double coffeeMilliliters = 50;
        private const decimal coffeePrice = 3.50M;

        public Coffee(string name, double caffeine) : base(name, coffeePrice, coffeeMilliliters)
        {
            Caffeine = caffeine;
        }

        public double Caffeine { get; set; }
    }
}
