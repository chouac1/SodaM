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
        string userChoice;
        public List<Can> sodaInventory;
        public List<Coin> coinInventory;  
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

        public void BuySoda() //call within simulation method
        {

            Console.WriteLine("Please make your selection\n 1) Orange Soda\n 2) Cola\n 3) Root Beer");
            userSelection = Console.ReadLine();

            if (userSelection == "1") 
            {
                ConfirmPurchse("Orange Soda", .06);
            }
            else if (userSelection == "2")
            {
                ConfirmPurchse("Cola", .35);
            }
            else if(userSelection == "3")
            {
                ConfirmPurchse("Root Beer", .60);
            }
            else
            { 
                Console.WriteLine("Please make another selection from our available inventory.");
                BuySoda();
                
                //What is another way to loop this without calling this method again?
                
            }
        }
        
        public void ConfirmPurchse(string soda, double price)
        {
            Console.WriteLine($"That would be ${price} cents. Would you like to continue your purchase, yes or no? ");
            userChoice = Console.ReadLine();
            if (userChoice == "yes")
            {
                
            }
            else
            {
                Console.WriteLine("Thanks for using our service!");
            }

            //activates a method to check how much money user has...
            //activates a if/else statement depending on if the user has enough money or not..
            //if yes, user's purchase has been successful and ask if they would like to make another purchse..
            //if no, prompt user letting them know that suffient funding is needed or make another selection..
        }

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
    }
}
