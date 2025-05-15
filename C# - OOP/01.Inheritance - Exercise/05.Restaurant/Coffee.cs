using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private double caffeine;
        private const double coffeMilliliters = 50;
        private const decimal coffePrice = 3.5m;
        public Coffee(string name, double caffeine) 
            : base(name, coffePrice, coffeMilliliters)
        {
            this.Caffeine = caffeine;
        }

      
        public double Caffeine { get=>caffeine; set=>caffeine=value; }


    }
}
