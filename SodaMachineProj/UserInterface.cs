using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SodaMachineProj
{
    public static class UserInterface
    {
        //US #5 console interactions inside this class


        public static void OpenMenu() 
        {

            Console.WriteLine("Please make your selection from below.");
            Console.WriteLine("1. Orange Soda, $.06");
            Console.WriteLine("2. Cola, $.35");
            Console.WriteLine("3. Root Beer, $.60");
            string input = Console.ReadLine();

            if (input == "1")
            {
                input = "Orange Soda";
                Console.WriteLine($"You have chosen{input}, great choice!");
            }
            else if (input == "2")
            {
                input = "Cola";
            }
            else if (input == "3")
            {
                input = "Root Beer";
            }
            else
            {
                Console.WriteLine("Please make another selection from our available inventory.");
                OpenMenu();

            }
        }

        public static string PickACoin()
        {
            Console.WriteLine("Select which coin you would like to insert.");
            Console.WriteLine("1. Quarter");
            Console.WriteLine("2. Dime");
            Console.WriteLine("3. Nickel");
            Console.WriteLine("4. Penny");

            string userInput = Console.ReadLine();

            if (userInput == "1")
            {
                userInput = "Quarter";
            }
            else if (userInput == "2")
            {
                userInput = "Dime";
            }
            else if (userInput == "3")
            {
                userInput = "Nickel";
            }
            else if (userInput == "4")
            {
                userInput = "Penny";
            }

            return userInput;


        }

        public static int NumberOfCoins()
        {
            Console.WriteLine("How many coins would you like to insert?");
            int coinAmount = int.Parse(Console.ReadLine());
            return coinAmount;
        }
    }
}
