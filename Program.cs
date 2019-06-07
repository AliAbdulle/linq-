using System;
using System.Collections.Generic;
using System.Linq;

namespace linq
{
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

            foreach (string name in descend)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("----------------------------");

            // Build a collection of these numbers sorted in ascending order
            List<int> numbersList = new List<int>()
             { 15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96};

            List<int> ascending = numbersList.OrderBy(n => n).ToList();

            foreach (int number in ascending)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine("----------------------------");

            // Output how many numbers are in this list
            List<int> Listnumber = new List<int>()
            {15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96};

            Console.WriteLine(Listnumber.Count);

            Console.WriteLine("----------------------------");

            // How much money have we made?
            List<double> purchases = new List<double>()
            {2340.29, 745.31, 21.76, 34.03, 4786.45, 879.45, 9442.85, 2454.63, 45.65};

            Console.WriteLine(purchases.Sum());

            Console.WriteLine("----------------------------");
        }
    }
}
