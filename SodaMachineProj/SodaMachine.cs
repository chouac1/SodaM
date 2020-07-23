using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace SodaMachineProj
{
    class SodaMachine
    {
        //Member Variables (Has A)
       
        public List<Can> sodaInventory;
        public List<Coin> coinInventory;
        public Wallet customerWallet;
        
        
        //money count: 20 quarters = $5, 10 dimes = $1, 50 pennies = .50
        //total amount to start: $6.50


        //Constructor (Spawner)

        public SodaMachine()
        {
            sodaInventory = new List<Can>();
            AddSodaInventory();
            coinInventory = new List<Coin>();
            AddCoins();
            

            
        }

        //Member Methods (Can Do)


        public void AddSodaInventory()
        {
            for (int i = 0; i < 11; i++)
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
        public void InsertCoins()
        {

            //DisplayCustomerWallet();

            Console.WriteLine("How many quarters would you like to insert?");
            int quarterInput = int.Parse(Console.ReadLine());

            Console.WriteLine($"You have inserted {quarterInput} quarters. Is that correct?");
            string userInput = Console.ReadLine();
            if (userInput == "yes")
            {


                for (int i = 0; i < customerWallet.customerWallet.Count; i++)
                {
                    Console.WriteLine(i);
                    Console.ReadLine();
                }

                //for (int i = 0; i == quarterInput; i--)
                //{
                //    if (quarterInput <= ) //counts
                //    { 
                //        wallet.customerWallet.Remove(new Quarter()); 
                //    }
                //    else if (quarterInput > wallet.customerWallet.Count<new Quarter>()
                //    {
                //        Console.WriteLine("Does not look like you have enough quarters.");
                //        Console.WriteLine("Please insert enough quarters, available, in your wallet.");
                //    }
                //}
                //for (int i = 0; i == quarterInput; i++)
                //{
                //    coinInventory.Add(new Quarter());
                //}

                //Console.WriteLine("How many dimes would you like to insert?");
                //int dimesInput = int.Parse(Console.ReadLine());

                //Console.WriteLine("How many nickels would you like to insert?");
                //int nickelsInput = int.Parse(Console.ReadLine());

                //Console.WriteLine("How many pennies would you like to insert?");
                //int penniesInput = int.Parse(Console.ReadLine());


            }
        }

        //public void DisplayCustomerWallet() //displays customer's available balance
        //{
        //    Console.WriteLine("You available balance is: " + wallet.customerWallet); // seems to be breaking the code??
            
        //}
        
        

    }
}
