using System;

namespace VendingMachine
{
    public class Bank
    {
        private int Balance { get; set; } = 100;
        private Menu Menu { get; }

        public Bank(Menu menu)
        {
            Menu = menu;
        }
        public int GetBalance()
        {
            return Balance;
        }

        public void Withdrawal(int cash)
        {
            Balance -= cash;
            
            BankMessage("New balance after purchase: $");
        }

        public void Beg()
        {
            Console.Clear();

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("I see that you're begging me for money, loser, haha, jk, ily.\n");
                Console.ResetColor();
                Console.WriteLine("\nSince we're friends I'll help you. How much do you need: $");
                var amount = Console.ReadLine();

                var validAmount = Int32.TryParse(amount, out int value);

                if (!validAmount)
                {
                    Menu.Error("Dude stop wasting my time, I'll ask again, how much");
                }
                
                if (value > 100 || value <= 0)
                {
                    Menu.Error("You can only ask between $1 and $100. Don't be weird");
                }
                
                if(validAmount && Balance + value > 350)
                {
                    Menu.Error("Dude, it seems like you already have a lot of money");
                    BankMessage("Your current balance is: $");
                    break;
                }
                
                if(validAmount && value <= 100 && value > 0)
                {
                    Balance += value;
                    BankMessage("New balance after begging: $");
                    break;
                }
            }
        }

        public void BankMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{message}{Balance}");
            Console.ResetColor();
        }
    }
}