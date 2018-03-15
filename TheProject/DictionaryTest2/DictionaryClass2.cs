using System;
using System.Linq;
using System.Collections.Generic;

namespace DictionaryTest2
{
    class DictionaryClass2
    {
        static void Main(string[] args)
        {
            //Dictionary <Color, Dictionary<Name, Money>>
            Dictionary<string, Dictionary<string, decimal>> salesPerColor =
                new Dictionary<string, Dictionary<string, decimal>>();
            string newInput = Console.ReadLine();
            while (true)
            {
                if (newInput == "End")
                {
                    break;
                }
                Person currPerson = ReadPerson(newInput);
                if (!salesPerColor.ContainsKey(currPerson.Color))
                {
                    Dictionary<string, decimal> currentInDict = new Dictionary<string, decimal>();
                    currentInDict.Add(currPerson.Name, currPerson.Money);
                    salesPerColor.Add(currPerson.Color, currentInDict);
                }
                else
                {
                    if (!salesPerColor[currPerson.Color].ContainsKey(currPerson.Name))
                    {
                        salesPerColor[currPerson.Color].Add(currPerson.Name, currPerson.Money);
                    }
                    else
                    {
                        salesPerColor[currPerson.Color][currPerson.Name] += currPerson.Money;
                    }
                }
                newInput = Console.ReadLine();
            }

            foreach (var person in salesPerColor.OrderBy(x => x.Key))
            {
                Console.WriteLine($"---------------------------------------");
                Console.WriteLine($"kvp.Value > 400 --> {person.Value.Count(kvp => kvp.Value > 400)}");
                Console.WriteLine($"---------------------------------------");
                Console.WriteLine($"{person.Key}");
                Console.WriteLine($"---------------------------------------");
                Dictionary<string, decimal> nameMoneys = person.Value;
                Console.WriteLine($"Count People with color {person.Key} --> {nameMoneys.Count}");
                Console.WriteLine($"People with more than 400 --> {nameMoneys.Count(kvp => kvp.Value > 400)}");
                foreach (var nameM in nameMoneys.Where(m => m.Value > 400).OrderBy(y => y.Value))
                {
                    Console.WriteLine($"Name {nameM.Key} --> Money used {nameM.Value}");
                }
            }
            Console.WriteLine($"Count Colors --> {salesPerColor.Count}");
            
            //Ivan apple red / 32 14.4
            //Slav; kiwi blue 17 33.10
            //Slav grape blue 18 , 12.4
            //Grigor apple red / 77 14.4
            //Mimi portocal blue  \ 19 18.8
            //Koni grape yellow / 33   17.6
            //Mihail orange yellow 33   18.20
            //End
        }

        static Person ReadPerson(string inputLine)
        {
            string[] input = inputLine
                .Split(new char[] { ' ', ';', ',', '/', '\\' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            return new Person
            {
                Name = input[0],
                Fruit = input[1],
                Color = input[2],
                Price = decimal.Parse(input[3]),
                Quantity = double.Parse(input[4])
            };
        }

    }

    class Person
    {
        public string Name { get; set; }
        public string Fruit { get; set; }
        public string Color { get; set; }
        public double Quantity { get; set; }
        public decimal Price { get; set; }

        public decimal Money
        {
            get
            {
                return (decimal)Quantity * Price;
            }
        }
    }
}
