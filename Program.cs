﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace linq
{
    // Define a bank
    public class Customer
    {
        public string Name { get; set; }
        public double Balance { get; set; }
        public string Bank { get; set; }
    }
    public class Bank
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
        public int MillionaireCount { get; set; }
    }

    public class Customer2
    {
        public string Name { get; set; }
        public double Balance { get; set; }
        public string Bank { get; set; }
    }
    public class Bank2
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
    }

     public class ReportItem
            {
                public string CustomerName { get; set; }
                public string BankName { get; set; }
                public string CustomerFullName()
                {
                    return this.CustomerName.Split(" ")[1];
                }
            }

    class Program
    {
        static void Main(string[] args)
        {
            //Restriction/Filtering Operations
            // Find the words in the collection that start with the letter 'L'
            List<string> fruits = new List<string>() { "Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry" };

            IEnumerable<string> LFruits = from fruit in fruits where fruit.StartsWith("L") select fruit;
            foreach (string fruit in LFruits)
            {
                Console.WriteLine(fruit);
            }
            Console.WriteLine("----------------------------");

            // Which of the following numbers are multiples of 4 or 6
            List<int> numbers = new List<int>()
            { 15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96};

            IEnumerable<int> fourSixMultiples = numbers.Where(number => number % 4 == 0 | number % 6 == 0);
            foreach (int number in fourSixMultiples)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine("----------------------------");

            //Ordering Operations
            // Order these student names alphabetically, in descending order (Z to A)
            List<string> names = new List<string>()
                {
                    "Heather", "James", "Xavier", "Michelle", "Brian", "Nina",
                    "Kathleen", "Sophia", "Amir", "Douglas", "Zarley", "Beatrice",
                    "Theodora", "William", "Svetlana", "Charisse", "Yolanda",
                    "Gregorio", "Jean-Paul", "Evangelina", "Viktor", "Jacqueline",
                    "Francisco", "Tre"
                };

            List<string> descend = names.OrderByDescending(name => name.First()).ToList();
            Console.WriteLine($"These student names alphabetically, in descending order is:");
            foreach (string name in descend)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("----------------------------");

            // Build a collection of these numbers sorted in ascending order
            List<int> numbersList = new List<int>()
             { 15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96};

            List<int> ascending = numbersList.OrderBy(n => n).ToList();

            Console.WriteLine($"The collection of the numbers sorted by ascending is:");
            foreach (int number in ascending)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine("----------------------------");

            // Output how many numbers are in this list
            List<int> Listnumber = new List<int>()
            {15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96};

            Console.WriteLine($"The Total number of the list is {Listnumber.Count}");

            Console.WriteLine("----------------------------");

            // How much money have we made?
            List<double> purchases = new List<double>()
            {2340.29, 745.31, 21.76, 34.03, 4786.45, 879.45, 9442.85, 2454.63, 45.65};

            Console.WriteLine($"The total amount pruchased is {purchases.Sum()}");

            Console.WriteLine("----------------------------");

            // What is our most expensive product?
            List<double> prices = new List<double>()
            { 879.45, 9442.85, 2454.63, 45.65, 2340.29, 34.03, 4786.45, 745.31, 21.76};

            Console.WriteLine($"The most expensive product is {prices.Max()}");

            Console.WriteLine("----------------------------");

            /*
             Store each number in the following List until a perfect square
             is detected.

             Ref: https://msdn.microsoft.com/en-us/library/system.math.sqrt(v=vs.110).aspx
            */
            List<int> wheresSquaredo = new List<int>()
            {66, 12, 8, 27, 82, 34, 7, 50, 19, 46, 81, 23, 30, 4, 68, 14};

            bool IsNumberSquare(int num)
            {
                int number = (int)Math.Sqrt(num);
                return num == number * number;
            }
            IEnumerable<int> squareNumbers = wheresSquaredo.TakeWhile(num => !IsNumberSquare(num));

            Console.WriteLine($"The perfect squere List detected is ");
            foreach (int num in squareNumbers)
            {
                Console.WriteLine(num);
            };
            Console.WriteLine("------------------------------------------------------------");

            // Build a collection of customers who are millionaires



            List<Customer> customers = new List<Customer>() {
            new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
            new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
            new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
            new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
            new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
            new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
            new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
            new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
            new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
            new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}

        };
            /* 
                Given the same customer set, display how many millionaires per bank.
                Ref: https://stackoverflow.com/questions/7325278/group-by-in-linq

                Example Output: 
                WF 2
                BOA 1
                FTB 1
                CITI 1
            */

            IEnumerable<Bank> millionairesBanks = (
            from millionaire in customers
            group millionaire by millionaire.Bank into ListMillionaries
            select new Bank
            {
                Name = ListMillionaries.Key,
                MillionaireCount  = ListMillionaries.Where(count => count.Balance >= 1000000)
                .ToList().Count()
            });
            Console.WriteLine("Given the same customer set, display how many millionaires per bank.");
            foreach(Bank bank in millionairesBanks)
            {
                Console.WriteLine($"{bank.Name} {bank.MillionaireCount}");
            }

            Console.WriteLine("------------------------------------------------------------");

            // Create some banks and store in a List
            List<Bank> bank2 = new List<Bank>() {
            new Bank(){ Name="First Tennessee", Symbol="FTB"},
            new Bank(){ Name="Wells Fargo", Symbol="WF"},
            new Bank(){ Name="Bank of America", Symbol="BOA"},
            new Bank(){ Name="Citibank", Symbol="CITI"},
        };

            // Create some customers and store in a List
            List<Customer2> customer2 = new List<Customer2>() {
            new Customer2(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
            new Customer2(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
            new Customer2(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
            new Customer2(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
            new Customer2(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
            new Customer2(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
            new Customer2(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
            new Customer2(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
            new Customer2(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
            new Customer2(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
        };
            /*
                You will need to use the `Where()`
                and `Select()` methods to generate
                instances of the following class.

                public class ReportItem
                {
                    public string CustomerName { get; set; }
                    public string BankName { get; set; }
                }
            */
            List<Customer2> ListOfMillionaries = customer2
            .Where(customer => customer.Balance >= 1000000).ToList();

            IEnumerable<ReportItem> millionaireReport = (
                from Customer in ListOfMillionaries
                join bank in  bank2
                on  Customer.Bank equals bank.Symbol
                select new ReportItem
                {
                    CustomerName = Customer.Name,
                    BankName = bank.Name
                }

            );
        Console.WriteLine("Customer Name and Bank List");
        foreach (var item in millionaireReport.OrderBy(name => name.CustomerFullName()))
            {
                Console.WriteLine($"{item.CustomerName} at {item.BankName}");
            }


        }
    }
}


