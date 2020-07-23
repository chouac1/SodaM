using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachineProj
{
    class Wallet
    {
        //Member Variables (Has A)

        public List<Coin> customerWallet; //

        //Constructor (Spawner)
        public Wallet()
        {
            customerWallet = new List<Coin>();
            AddCustomerCoins(); //current inventory: 8 quarters, 10 dimes, 20 nickels, 100 pennies ($2 quarters, $1 each).
        }

        //Member Methods (Can Do)

        public void AddCustomerCoins()
        {
            for (int i = 0; i < 2; i++)
            {
                customerWallet.Add(new Quarter());
            }
            for (int i = 0; i < 2; i++)
            {
                customerWallet.Add(new Dime());
            }
            for (int i = 0; i < 2; i++)
            {
                customerWallet.Add(new Nickel());
            }
            for (int i = 0; i < 2; i++)
            {
                customerWallet.Add(new Penny());
            }
        }
    }
}
