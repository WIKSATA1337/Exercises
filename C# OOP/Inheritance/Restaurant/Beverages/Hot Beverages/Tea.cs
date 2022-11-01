using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Beverage.Beverages
{
    public class Tea : HotBeverage
    {
        public Tea(string name, decimal price, double milliliters) : base(name, price, milliliters)
        {
        }
    }
}
