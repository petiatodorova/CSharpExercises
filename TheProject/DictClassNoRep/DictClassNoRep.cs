using System;
using System.Collections.Generic;
using System.Linq;

namespace DictClassNoRep
{
    class DictClassNoRep
    {
        static void Main(string[] args)
        {
            //за повтарящи се имена за различните цветове добавя тотала към предния

            //Ivan apple red / 32 14.4
            //Slav; kiwi blue 17 33.10
            //Slav grape blue 18 , 12.4
            //Grigor apple red / 77 14.4
            //Mimi portocal blue  \ 19 18.8
            //Koni grape yellow / 33   17.6
            //Mihail orange yellow 33   18.20
            //End

            string input = Console.ReadLine();
            //Dictionary<color, Dict<name, totalmoney>>
            //
            Dictionary<string, Dictionary<string, decimal>> users = new Dictionary<string, Dictionary<string, decimal>>();

            while (true)
            {
                if (input == "End")
                {
                    break;
                }
                User curUser = ReadUser(input);
                string color = curUser.Color;
                string name = curUser.Name;
                decimal money = curUser.TotalMoney;

                if (!users.ContainsKey(color))
                {
                    Dictionary<string, decimal> currentNameMoney = new Dictionary<string, decimal>();
                    currentNameMoney.Add(name, money);
                    users.Add(color, currentNameMoney);
                }
                else if (!users[color].ContainsKey(name))
                {
                    users[color].Add(name, money);
                }
                else
                {
                    users[color][name] += money;
                }
                input = Console.ReadLine();
            }

            foreach (var user in users.OrderBy(x => x.Key))
            {
                string theColor = user.Key;
                Dictionary<string, decimal> theNamesMoney = user.Value;
                Console.WriteLine($"The Color is: ---> {theColor}");
                foreach (var nameMoney in theNamesMoney.OrderBy(x => x.Value))
                {
                    Console.WriteLine($"Name is: {nameMoney.Key} Money are: {nameMoney.Value}");
                }
            }
        }

        static User ReadUser(string input)
        {
            string[] arrInput = input
                .Split(new char[] {' ',',','/','\\',';' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            return new User
            {
                Name = arrInput[0],
                Fruit = arrInput[1],
                Color = arrInput[2],
                Quantity = decimal.Parse(arrInput[3]),
                Price = decimal.Parse(arrInput[4])
            };
        }
    }

    class User
    {
        public string Name { get; set; }
        public string Fruit { get; set; }
        public string Color { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }

        public decimal TotalMoney
        {
            get
            {
                return Quantity * Price;
            }
            set
            {
            }
        }
    }
}
