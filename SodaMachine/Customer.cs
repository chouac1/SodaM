using System;
using System.Collections.Generic;
using System.Text;

namespace SodaMachine
{
    public class Customer
    {
        public Wallet wallet;
        public Backpack backpack;

        public Customer()
        {
            wallet = new Wallet();
            backpack = new Backpack();
        }

        public List<Coin> ChooseCoinsToDeposit()
        {
            List<Coin> deposit = null;
            bool input = true;
            while(input)
            {
                bool success = Int32.TryParse(UserInterface.DisplayCoinSelection(), out int coinChoice);
                Console.Clear();
                if (success && coinChoice > 0 && coinChoice < 5)
                {
                    if (wallet.ContainsCoin(coinChoice))
                    {
                        wallet.RemoveCoin(coinChoice);
                        deposit = DepositSingleCoin(coinChoice, deposit);
                    }
                    else
                        UserInterface.NoCoinMessage(coinChoice);
                }
                else if (coinChoice == 5)
                {
                    if (deposit != null)
                        input = false;
                }
                else if (coinChoice == 6)
                {
                    if (deposit != null)
                    {
                        wallet.AcceptCoins(deposit);
                        deposit.Clear();
                    }
                }
                UserInterface.WelcomeMessage();
                UserInterface.DisplayValue("deposited", deposit);
            }
            return deposit;
        }

        public List<Coin> DepositSingleCoin(int coinChoice, List<Coin> deposit)
        {
            if (deposit == null)
                deposit = new List<Coin>();

            switch(coinChoice)
            {
                case 1:
                    deposit.Add(new Quarter());
                    break;
                case 2:
                    deposit.Add(new Dime());
                    break;
                case 3:
                    deposit.Add(new Nickel());
                    break;
                case 4:
                    deposit.Add(new Penny());
                    break;
                default:
                    break;
            }
            return deposit;
        }

    }
}
