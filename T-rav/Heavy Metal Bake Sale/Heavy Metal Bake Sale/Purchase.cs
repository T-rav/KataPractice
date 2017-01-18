using System;
using System.Collections.Generic;

namespace Heavy_Metal_Bake_Sale
{
    public class Purchase
    {
        private readonly IConsole _console;

        public Purchase(IConsole console)
        {
            _console = console;
        }

        public string GetItemsToPurchase()
        {
            _console.WriteLine("Items to Purchase > ");
            return _console.ReadLine();
        }

        public void PrintTotal(string itemsPurchased)
        {
            var itemPrices = new Dictionary<string, double>
            {
                { "B", 0.65 },
                { "M", 1.00 },
                { "C", 1.35 },
                { "W", 1.50 }
            };

            var total = TotalPurchases(itemsPurchased, itemPrices);

            var printTotal = total.ToString("F2");
            _console.WriteLine($"Total > ${printTotal}");
        }

        private double TotalPurchases(string itemsPurchased, IReadOnlyDictionary<string, double> itemPrices)
        {
            var purchases = itemsPurchased.Split(',');
            var total = 0.0;
            foreach (var purchase in purchases)
            {
                double itemPrice;
                itemPrices.TryGetValue(purchase.Trim(), out itemPrice);
                total += itemPrice;
            }
            return total;
        }
    }
}