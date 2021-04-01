using System;
using System.Collections.Generic;

namespace VendingMachine
{
    public class VendingMachine
    {
        private Bank Bank { get; }
        private Menu Menu { get; }

        private Inventory Inventory { get; }
        
        private readonly List<string> _menuSelections = new List<string>
        {
            "purchase",
            "balance",
            "history",
            "bye",
            "back"
        };
        
        private readonly List<string> _purchaseSelections = new List<string>
        {
            "purchase",
            "beg",
            "balance",
            "back"
        };

        public VendingMachine(Menu menu, Inventory inventory, Bank bank)
        {
            Menu = menu;
            Inventory = inventory;
            Bank = bank;
        }

        public void Start()
        {
            Menu.Selection();

            while (true)
            {
                var command = Menu.GetSelection(_menuSelections);
                
                if (command == "purchase")
                {
                    Purchase();
                    break;
                }

                if (command == "balance")
                {
                    Bank.BankMessage("Your current balance is: $");
                }

                if (command == "bye")
                {
                    Console.ForegroundColor = ConsoleColor.Yellow; 
                    Console.WriteLine("\nByebye~ see you next time! ~\n");
                    Console.ResetColor();

                    break;
                }

                if (command == "back" || command == "back")
                {
                    Console.Clear();
                    Menu.Selection();
                }

                if (command != "back" || command != "purchase")
                {
                    Console.WriteLine("\nWhat do you want to do next?");
                    Console.WriteLine("Write 'back' if you want to see menu selection again.\n");
                }
            }
        }

        private void Purchase()
        {
            Console.Clear();
            Inventory.ListItems();
            Console.WriteLine("What do you want to buy? Select by writing the CODE of the item\n");
            Bank.BankMessage("Your current balance is: $");

            var buySelections = Inventory.GetCodes();
            var selectedItem = Menu.GetSelection(buySelections);
            
            var item = Inventory.GetItem(selectedItem);
            var itemCost = Inventory.GetCost(selectedItem);

            var balance = Bank.GetBalance();

            if (itemCost <= balance)
            {
                Menu.BuySuccess(item);
                Bank.Withdrawal(itemCost);

                Console.WriteLine("\nWant to buy something else?");
                PurchaseMenu();
            }
            else
            {
                Menu.Error("You don't have enough money to buy this item!");
                Console.WriteLine("\nOh, you're out of money?");

                PurchaseMenu();
            }
        }

        private void PurchaseMenu()
        {
            while (true)
            {
                Menu.PurchaseSelection();
                var command = Menu.GetSelection(_purchaseSelections);

                if(command == "purchase")
                {
                    Purchase();
                }

                if(command == "beg")
                {
                    Bank.Beg();
                }

                if(command == "balance")
                {
                    Bank.BankMessage("Your current balance is: $");
                }

                if (command == "back")
                {
                    break;
                }
            }
            
            Console.Clear();
            Start();
        }
    }
}