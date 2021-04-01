using System;

namespace VendingMachine
{
    public class VendingItem
    {
        public string Product { get; set;  }
        public int Cost { get; set; }
        public int Code { get; set; }
        

        public VendingItem(string product, int cost, int code)
        {
            Product = product;
            Cost = cost;
            Code = code;
        }
    }
}