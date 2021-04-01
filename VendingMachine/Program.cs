using System;
using System.Collections.Generic;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            var vendingMachine = new VendingMachine(
                new Menu(),
                new Inventory(),
                new Bank(new Menu())
            );

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("HI, NICE TO MEET YOU, I'M THE VENDING MACHINE! ◡̈\n");
            Console.ResetColor();
            Console.WriteLine("What do you want to do?");
            
            vendingMachine.Start();
        }
    }
}