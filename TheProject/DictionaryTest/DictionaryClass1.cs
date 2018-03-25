using System;
using System.Linq;
using System.Collections.Generic;

namespace DictionaryTest
{
    class DictionaryClass1
    {
        static void Main(string[] args)
        {
            /* Tests
             * 
             * Ivan apple red / 32 14.4
             * Ivan; kiwi blue 17 33.10
             * Ivan grape blue 18 , 12.4
             * Mimi orange blue  \ 19 18.8
             * Mihail orange yellow 33   18.20
             * End

             * SortedDictionary <Color, SortedDictionary<Name, Money>>
            */
            SortedDictionary<string, SortedDictionary<string, decimal>> salesPerColor = 
                new SortedDictionary<string, SortedDictionary<string, decimal>>();
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
                    SortedDictionary<string, decimal> currentInDict = new SortedDictionary<string, decimal>();
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

            foreach (var person in salesPerColor)
            {
                Console.WriteLine($"{person.Key}");
                Console.WriteLine($"---------------------------------------");
                SortedDictionary<string, decimal> nameMoneys = person.Value;
                foreach (var nameM in nameMoneys)
                {
                    Console.WriteLine($"Name {nameM.Key} -- Money used {nameM.Value}");
                    Console.WriteLine($"*****************************************");
                }

            }

        }

        static Person ReadPerson(string inputLine)
        {
            string[] input = inputLine
                .Split(new char[] {' ', ';', ',', '/', '\\' }, StringSplitOptions.RemoveEmptyEntries)
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
