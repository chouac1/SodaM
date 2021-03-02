using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SodaMachine
{
    public class SodaMachine
    {
        public List<Coin> register;
        public List<Can> inventory;
        public SodaMachine()
        {
            register = new List<Coin>();
            inventory = new List<Can>();
            FillRegister();
            FillStock();
        }

        public void FillRegister()
        {
            AddCoinsToRegister(20, new Quarter());
            AddCoinsToRegister(10, new Dime());
            AddCoinsToRegister(20, new Nickel());
            AddCoinsToRegister(50, new Penny());
        }

        public void AddCoinsToRegister(int numberOfCoins, Coin typeOfCoin)
        {
            for (int i = 0; i < numberOfCoins; i++)
            {
                register.Add(typeOfCoin);
            }
        }

        public int Execute(Customer customer, string sodaChoice, List<Coin> deposit)
        {
            double payment = AcceptCoins(deposit);
            Can selection = PrepareCan(sodaChoice);
            double change = DetermineAmountOfChange(selection, payment);
            int statusCode = AttemptSale(change);

            switch (statusCode)
            {
                case 1:
                    EjectDeposit(deposit);
                    customer.wallet.AcceptCoins(deposit);
                    break;
                case 2:
                    EjectDeposit(deposit);
                    customer.wallet.AcceptCoins(deposit);
                    break;
                case 3:
                    DispenseSodaToCustomer(customer, selection);
                    break;
                case 4:
                    DispenseSodaToCustomer(customer, selection);
                    List<Coin> refund = CreateChange(change);
                    customer.wallet.AcceptCoins(refund);
                    break;
                case 5:
                    EjectDeposit(deposit);
                    customer.wallet.AcceptCoins(deposit);
                    break;
                default:
                    EjectDeposit(deposit);
                    customer.wallet.AcceptCoins(deposit);
                    break;
            }
            UserInterface.DecodeStatusCode(statusCode, sodaChoice, change, payment);

            return statusCode;
        }

        public void FillStock()
        {
            for (int i = 0; i < 10; i++)
            {
                inventory.Add(new Cola());
                inventory.Add(new OrangeSoda());
                inventory.Add(new RootBeer());
            }
        }

        public bool ContainsCoin(string coinName)
        {
            bool found = false;
            foreach (Coin coin in register)
            {
                if (coin.name == coinName)
                {
                    found = true;
                    break;
                }
            }
            return found;
        }

        public double AcceptCoins(List<Coin> deposit)
        {
            foreach (Coin coin in deposit)
                register.Add(coin);

            return UserInterface.CheckValue(deposit);
        }

        public Can PrepareCan(string canChoice)
        {
            Can actualCan = null;
            switch (canChoice)
            {
                case "cola":
                    Can cola = new Cola();
                    if (ContainsCan(cola))
                        actualCan = cola;
                    break;
                case "orange soda":
                    Can orange = new OrangeSoda();
                    if (ContainsCan(orange))
                        actualCan = orange;
                    break;
                case "root beer":
                    Can rootbeer = new RootBeer();
                    if (ContainsCan(rootbeer))
                        actualCan = rootbeer;
                    break;
                default:
                    break;
            }
            return actualCan;
        }

        public bool ContainsCan(Can selection)
        {
            bool found = false;
            foreach (Can can in inventory)
            {
                if (can.name == selection.name)
                {
                    found = true;
                    break;
                }
            }
            return found;
        }

        public double DetermineAmountOfChange(Can can, double payment)
        {
            double change = -100;
            if (can != null)
                change = payment - can.Cost;
            return change;
        }

        public int AttemptSale(double change)
        {
            int statusCode = 0;
            if (change == -100)
                statusCode = 1;
            else if (change < 0)
                statusCode = 2;
            else if (change == 0)
                statusCode = 3;
            else if (change > 0)
            {
                List<Coin> refund = CreateChange(change);
                if (refund.Count > 0)
                {
                    statusCode = 4;
                    AcceptCoins(refund);
                }
                else
                    statusCode = 5;
            }
            return statusCode;
        }

        public List<Coin> CreateChange(double changeAmount)
        {
            List<Coin> refund = new List<Coin>();

            foreach (Coin coin in register.ToList())
            {
                changeAmount = Math.Round(changeAmount, 2);
                if (coin.Value == 0.25 && changeAmount >= 0.25)
                {
                    changeAmount -= 0.25;
                    register.Remove(coin);
                    refund.Add(coin);
                }
                else if (coin.Value == 0.10 && changeAmount >= 0.10)
                {
                    changeAmount -= 0.10;
                    register.Remove(coin);
                    refund.Add(coin);
                }
                else if (coin.Value == 0.05 && changeAmount >= 0.05)
                {
                    changeAmount -= 0.05;
                    register.Remove(coin);
                    refund.Add(coin);
                }
                else if (coin.Value == 0.01 && changeAmount >= 0.01)
                {
                    changeAmount -= 0.01;
                    register.Remove(coin);
                    refund.Add(coin);
                }
            }
            changeAmount = Math.Round(changeAmount, 2);
            if (changeAmount != 0)
            {
                AcceptCoins(refund);
                refund.Clear();
            }
            return refund;
        }

        public void EjectDeposit(List<Coin> coins)
        {
            foreach (Coin coin in coins)
            {
                register.Remove(coin);
            }
        }

        public void DispenseSodaToCustomer(Customer customer, Can selection)
        {
            RemoveCan(selection);
            customer.backpack.cans.Add(selection);
        }

        public void RemoveCan(Can can)
        {
            for (int i = 0; i < inventory.Count; i++)
            {
                if (inventory[i].name == can.name)
                {
                    inventory.RemoveAt(i);
                    break;
                }
            }
        }
    }
}
