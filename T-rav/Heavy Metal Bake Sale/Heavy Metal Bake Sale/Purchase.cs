using System.Collections.Generic;
using Heavy_Metal_Bake_Sale_Tests;

namespace Heavy_Metal_Bake_Sale
{
    public class Purchase
    {
        public string GetItemsToPurchase()
        {
            return "Items to Pruchase > ";
        }

        public string GetItemsToPurchase(IConsole consoleLineReader)
        {
            return consoleLineReader.ReadLine();
        }

        public string PrintTotal(string itemsPurchased)
        {
            var itemPrices = new Dictionary<string, double>
            {
                { "B", 0.65 },
                { "M", 1.00 },
                { "C", 1.35 },
                { "W", 1.50 }
            };

            var purchases = itemsPurchased.Split(',');
            var total = 0.0;
            foreach (var purchase in purchases)
            {
                double itemPrice;
                itemPrices.TryGetValue(purchase, out itemPrice);
                total += itemPrice;
            }

            var printTotal = total.ToString("F2");
            return $"Total > ${printTotal}";
        }
    }
}