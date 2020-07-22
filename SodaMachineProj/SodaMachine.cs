using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachineProj
{
    class SodaMachine
    {
        //Member Variables (Has A)

        string userSelection;
        public List<Can> sodaInventory;
        public List<Coin> coinInventory;  

        

        //Constructor (Spawner)

        public SodaMachine()
        {
            sodaInventory = new List<Can>(); 
            AddSodaInventory();
            coinInventory = new List<Coin>();
            AddCoins();
            


            


        }

        //Member Methods (Can Do)

        public void BuySoda()
        {
            Console.WriteLine("Today's inventory is: " + sodaInventory + "  Please make a selection.");
            userSelection = Console.ReadLine();

            if (userSelection == "OrangeSoda") //.ToString will not convert class to a string
            {
                Console.WriteLine("Please insert .06 cents.");
            }
            else if (userSelection == "Cola")
            {
                Console.WriteLine("Please insert .35 cents.");
            }
            else if(userSelection == "RootBeer")
            {
                Console.WriteLine("Please insert .60 cents.");
            }
            else
            { 
                Console.WriteLine("Please make a selection from our available inventory."); 
            }
        }     
        
        public void AddSodaInventory()
        {
            for (int i = 0; i < 6; i++)
            {
                sodaInventory.Add(new Cola());
                sodaInventory.Add(new OrangeSoda()); 
                sodaInventory.Add(new RootBeer());
            }
            
        }

        public void AddCoins()
        {
            for (int i = 0; i < 21; i++)
            {
                coinInventory.Add(new Quarter());
                
            }

            for (int i = 0; i < 11; i++)
            {
                coinInventory.Add(new Dime());
                
            }

            for (int i = 0; i < 21; i++)
            {
                coinInventory.Add(new Nickel());
                
            }
            for (int i = 0; i < 51; i++)
            {
                coinInventory.Add(new Penny());
            }

            
        }
    }
}
