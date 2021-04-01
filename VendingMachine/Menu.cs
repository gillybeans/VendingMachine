using System;
using System.Collections.Generic;

namespace VendingMachine
{
    public class Menu
    {
        public void Selection()
        {
            Console.WriteLine("\nOPTIONS");
            Console.WriteLine("> {0,-10} {1,-20}", "purchase", "To buy an item");
            Console.WriteLine("> {0,-10} {1,-20}", "balance", "To see your current balance");
            Console.WriteLine("> {0,-10} {1,-20}\n", "bye", "You want to leave me? :(");
        }

        public void PurchaseSelection()
        {
            Console.WriteLine("\nMORE OPTIONS");
            Console.WriteLine("> {0,-10} {1,-20}", "purchase", "To buy something else");
            Console.WriteLine("> {0,-10} {1,-20}", "beg", "To beg me for some money :)");
            Console.WriteLine("> {0,-10} {1,-20}", "balance", "To see your current balance");
            Console.WriteLine("> {0,-10} {1,-20}\n", "back", "To go back to the main menu");
        }

        public string GetSelection(List<string> command)
        {
            while (true)
            {
                Console.Write("Select: ");
                Console.ForegroundColor = ConsoleColor.DarkMagenta;

                var input = Console.ReadLine();
                Console.ResetColor();

                if (command.Contains(input))
                {
                    return input;
                }
                
                Error("Please make a valid selection");
            }
        }

        public void BuySuccess(string item)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine($"\nWoohoo you bought {item}\n");
        }

        public void Error(string error)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{error}\n");
            Console.ResetColor();
        }
    }
}