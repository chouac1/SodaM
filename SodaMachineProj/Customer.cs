using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachineProj
{
    class Customer
    {
        //Member Variables (Has A)

        Wallet wallet;
        Backpack backpack;

        //Constructor (Spawner)
        public Customer()
        {
            wallet = new Wallet();
            backpack = new Backpack();
        }

        //Member Methods (Can Do)

        //display wallet amount
        //create a method that iterates through the wallet's list, calls a method on the user interface that displays the wallet contents.
        //not needed for MVP, come back to this


        //select coins
        public Coin SelectACoin()
        {

            string userInput = UserInterface.PickACoin();
            int userCoinMultiplier = UserInterface.NumberOfCoins();

            Coin coin = null;


            for (int coinCount = 0; coinCount < userCoinMultiplier; coinCount++)
            {
                for (int i = 0; i < wallet.customerWallet.Count; i++)
                {
                    if (userInput == wallet.customerWallet[i].name)
                    {
                        coin = wallet.customerWallet[i];

                        break;
                    }
                }

                if (coin == null)
                {
                    SelectACoin();

                }


            }

            wallet.customerWallet.Remove(coin);
            return coin;

        }

        //putting cans in backpack
        public void AddCansToBackPack(Can can)
        {
            backpack.backpackInventory.Add(can);
        }
    }
}
