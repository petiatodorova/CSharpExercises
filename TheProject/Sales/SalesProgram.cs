using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sales
{
    class SalesProgram
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            SortedDictionary<string, decimal> sales = new SortedDictionary<string, decimal>();

            for (int i = 0; i < n; i++)
            {
                Sale currSale = ReadSale();
                if (!sales.ContainsKey(currSale.Town))
                {
                    sales[currSale.Town] = currSale.TotalSales;
                }
                else
                {
                    sales[currSale.Town] += currSale.TotalSales;
                }

            }

            foreach (var town in sales.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{town.Key} -> {town.Value:F2}");
            }
        }

        static Sale ReadSale()
        {
            string[] saleParts = Console.ReadLine()
                .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            return new Sale
            {
                Town = saleParts[0],
                Product = saleParts[1],
                Price = decimal.Parse(saleParts[2]),
                Quantity = double.Parse(saleParts[3])
            };
        }
    }

    class Sale
    {
        public string Town { get; set; }
        public string Product { get; set; }
        public decimal Price { get; set; }
        public double Quantity { get; set; }

        public decimal TotalSales
        {
            get
            {
                return Price * (decimal)Quantity;
            }
        }
    }
}
