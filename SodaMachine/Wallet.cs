using System;
using System.Collections.Generic;
using System.Text;

namespace SodaMachine
{
    public class Wallet
    {
        public List<Coin> coins;
        public Wallet()
        {
            coins = new List<Coin>();
            FillWallet();
        }

        public void FillWallet()
        {
            AddCoinsToWallet(10, new Quarter());
            AddCoinsToWallet(10, new Dime());
            AddCoinsToWallet(10, new Nickel());
            AddCoinsToWallet(10, new Penny());
        }

        public void AddCoinsToWallet(int numberOfCoins, Coin typeOfCoin)
        {
            for (int i = 0; i < numberOfCoins; i++)
            {
                coins.Add(typeOfCoin);
            }
        }

        public bool ContainsCoin(int coinChoice)
        {
            bool found = false;
            string coinName = UserInterface.DecodeCoinSelection(coinChoice);
            foreach (Coin coin in coins)
            {
                if (coin.name == coinName)
                {
                    found = true;
                    break;
                }
            }
            return found;
        }

        public void RemoveCoin(int coinChoice)
        {
            string coinName = UserInterface.DecodeCoinSelection(coinChoice);
            for (int i = 0; i < coins.Count; i++)
            {
                if (coins[i].name == coinName)
                {
                    coins.RemoveAt(i);
                    break;
                }
            }
        }

        public void AcceptCoins(List<Coin> returnedAmount)
        {
            foreach (Coin coin in returnedAmount)
            {
                coins.Add(coin);
            }
        }
    }
}
