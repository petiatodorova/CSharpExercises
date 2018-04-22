using System;
using System.Collections.Generic;
using System.Linq;

namespace DictClassRep1
{
    class DictOk
    {
        static void Main(string[] args)
        {
            // Dictionary which holds the color as a Key Value and a List of Customr objects as Value
            Dictionary<string, List<Customer>> customers = new Dictionary<string, List<Customer>>();
            string newInput = Console.ReadLine();

            while (true)
            {
                if (newInput == "End")
                {
                    break;
                }
                Customer currCustomer = ReadCustomr(newInput);
                string color = currCustomer.Color;
                
                if (!customers.ContainsKey(color))
                {
                    customers[color] = new List<Customer>();
                }
                customers[color].Add(currCustomer);

                newInput = Console.ReadLine();
            }

            foreach (var cust in customers)
            {
                string theColor = cust.Key;
                Console.WriteLine($"The Color: --> {theColor}");
                List<Customer> theValues = cust.Value;
                foreach (var person in theValues.OrderBy(x => x.Name))
                {
                    Console.WriteLine($"Name: {person.Name} --> Total Money: {person.TotalMoney}");
                }
            }
        }

        static Customer ReadCustomr(string input)
        {
            string[] inputArr = input
                .Split(new char[] { ' ', '/', '\\', ';', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            return new Customer
            {
                Name = inputArr[0],
                Fruit = inputArr[1],
                Color = inputArr[2],
                Quantity = double.Parse(inputArr[3]),
                Price = decimal.Parse(inputArr[4])
            };
        }
    }

    class Customer
    {
        public string Name { get; set; }
        public string Fruit { get; set; }
        public string Color { get; set; }
        public double Quantity { get; set; }
        public decimal Price { get; set; }

        public decimal TotalMoney
        {
            get
            {
                return (decimal)Quantity * Price;
            }
        }
    }
}

/* Allows repeating names for the different colors
 * Tests:
 * Ivan apple red / 32 14.4
 * Slav; kiwi blue 17 33.10
 * Slav grape blue 18 , 12.4
 * Grigor apple red / 77 14.4
 * Mimi orange blue  \ 19 18.8
 * Koni grape yellow / 33   17.6
 * Mihail orange yellow 33   18.20
 * End
*/
