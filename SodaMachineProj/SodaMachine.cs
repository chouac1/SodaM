using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachineProj
{
    class SodaMachine
    {
        //Member Variables (Has A)

        public Type sodaInventory;
        public Type coinInventory;


        //Constructor (Spawner)

        public SodaMachine()
        {

            sodaInventory = new List<Type>() { };
            
            List<Type> coinInventory = new List<Type> (){ };
            


        }

        //Member Methods (Can Do)
    }
}
