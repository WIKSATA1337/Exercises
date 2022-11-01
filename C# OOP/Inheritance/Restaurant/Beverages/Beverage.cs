﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Beverage
{
    public class Beverage : Product
    {
        public Beverage(string name, decimal price, double milliliters) : base(name, price)
        {
            Milliliters = milliliters;
        }

        public virtual double Milliliters { get; set; }
    }
}
