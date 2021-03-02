using System;
using System.Collections.Generic;
using System.Text;

namespace SodaMachine
{
    public static class UserInterface
    {
        public static void WelcomeMessage()
        {
            Console.WriteLine("Welcome to CC's Soda!" + "\nOur inventory: Cola (.35), Orange (.06), Root Beer (.60)");
        }
        public static string ChooseSoda()
        {
            Console.WriteLine("Please choose between (1) Cola, (2) Orange Soda, (3) Root Beer.");
            string sodaChoice = "";

            while (sodaChoice == "")
            {
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        sodaChoice = "cola";
                        break;
                    case "2":
                        sodaChoice = "orange soda";
                        break;
                    case "3":
                        sodaChoice = "root beer";
                        break;
                    default:
                        Console.WriteLine("Please choose again.");
                        break;
                }
            }

            return sodaChoice;        
        }

        public static string DisplayCoinSelection()
        {
            Console.WriteLine("Please input desired coins"
                + "\nPress 1 for quarter"
                + "\nPress 2 for dime"
                + "\nPress 3 for nickel"
                + "\nPress 4 for penny"
                + "\nPress 5 when done to select a soda"
                + "\nPress 2 to cancel and refund"
                );
            string coinChoice = Console.ReadLine();
            return coinChoice;
        }

        public static string AskForAnotherSoda()
        {
            Console.WriteLine("Do you want to purchase another soda?"
                + "\nPress 1 for yes"
                + "\nPress 2 for no");
            string anotherSoda = Console.ReadLine();
            return anotherSoda;
        }

        public static double CheckValue(List<Coin> coins)
        {
            if (coins == null)
            {
                return 0;
            }
            double totalValue = 0;
            foreach (Coin coin in coins)
            {
                totalValue += coin.Value;
            }
            return Math.Round(totalValue, 2);
        }

        public static string DecodeCoinSelection(int consoleChoice)
        {
            string coinName = "";
            switch (consoleChoice)
            {
                case 1:
                    coinName = "quarter";
                    break;
                case 2:
                    coinName = "dime";
                    break;
                case 3:
                    coinName = "nickel";
                    break;
                case 4:
                    coinName = "penny";
                    break;
            }

            return coinName;
        }

        public static void DecodeStatusCode(int statusCode, string sodaChoice, double change, double payment)
        {
            switch (statusCode)
            {
                case 1:
                    Console.WriteLine($"Out of {sodaChoice}. Collect {payment} below and try again.");
                    break;
                case 2:
                    Console.WriteLine($"Insufficient payment for {sodaChoice}. Collect {payment} below and try again.");
                    break;
                case 3:
                    Console.WriteLine($"Enjoy your {sodaChoice}. Thanks for usig the exact change!");
                    break;
                case 4:
                    Console.WriteLine($"Enjoy your {sodaChoice}. Collect {change} below.");
                    break;
                case 5:
                    Console.WriteLine($"Insufficient change to complete refund, we apologize for the inconvenience. Collect {payment} below.");
                    break;
                default:
                    Console.WriteLine($"ERROR: Status Unknown. Returning {payment}");
                    break;
            }
        }

        public static void DisplayValue(string message, List<Coin> coins)
        {
            Console.WriteLine($"Total Amount {message}: {UserInterface.CheckValue(coins)}");
        }

        public static void NoCoinMessage(int coinChoice)
        {
            string coinName = UserInterface.DecodeCoinSelection(coinChoice);
            Console.WriteLine($"You don't have any coins of type: {coinName}!");
        }
    }
}
