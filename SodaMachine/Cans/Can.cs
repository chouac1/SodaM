using System;
using System.Collections.Generic;
using System.Text;

namespace SodaMachine
{
    public abstract class Can
    {
        public string name;
        protected double cost;
        public double Cost
        {
            get
            {
                return cost;
            }
        }
    }
}
