using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BorderControl
{
    public abstract class BaseBuyer : IBuyer
    {
        protected abstract int IncreasedFood { get; }

        public int Food { get; private set; }

        public void BuyFood()
        {
            Food += IncreasedFood;
        }
    }
}
