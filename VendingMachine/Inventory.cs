using System;
using System.Collections.Generic;

namespace VendingMachine
{
    public class Inventory
    {
        private readonly List<VendingItem> _items = new List<VendingItem>();
        
        public Inventory()
        {
            _items.Add(new VendingItem("Coffee", 20, 01));
            _items.Add(new VendingItem("Ramen", 75, 02));
            _items.Add(new VendingItem("Kimchi Jjigae", 115, 03));
            _items.Add(new VendingItem("Salad", 40, 04));
            _items.Add(new VendingItem("Simple Potato", 190, 05));
        }
        
        public void ListItems()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("      - - VENDING ITEMS - - \n");
            Console.WriteLine("  {0,-5}  {1,-16}  {2,-5}\n", "CODE", "ITEM", "COST");

            foreach (var item in _items)
            {
                Console.WriteLine("| {0,-5}| {1,-16}| ${2,5}|", item.Code, item.Product, item.Cost);
            }

            Console.WriteLine();
            Console.ResetColor();
        }

        public List<string> GetCodes()
        {
            var codes = new List<string>();

            foreach (var item in _items)
            {
                codes.Add(item.Code.ToString());
            }

            return codes;
        }

        public string GetItem(string code)
        {
            foreach (var item in _items)
            {
                if (item.Code == Int32.Parse(code))
                {
                    return item.Product;
                }
            }

            throw new ArgumentException("The item doesn't exist in the inventory!", nameof(code));
        }

        public int GetCost(string code)
        {
            foreach (var item in _items)
            {
                if (item.Code == Int32.Parse(code))
                {
                    return item.Cost;
                }
            }

            throw new ArgumentException("The item doesn't exist in the inventory!", nameof(code));
        }
    }
}