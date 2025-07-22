using System;
using System.Collections.Generic;
using System.Linq;

namespace CollectionsApp
{
    public class Program
    {
        // Using Dictionary<string, List<string>> so we can append values to existing keys
        static Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();

        public static void Main()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("a: Populate Dictionary");
                Console.WriteLine("b: Display Dictionary Contents");
                Console.WriteLine("c: Remove a Key");
                Console.WriteLine("d: Add a New Key and Value");
                Console.WriteLine("e: Add a Value to an Existing Key");
                Console.WriteLine("f: Sort the Keys");
                Console.WriteLine("x: Exit");

                Console.Write("Enter choice: ");
                string choice = Console.ReadLine();

                switch (choice.ToLower())
                {
                    case "a":
                        PopulateDictionary();
                        break;
                    case "b":
                        DisplayDictionary();
                        break;
                    case "c":
                        RemoveKey();
                        break;
                    case "d":
                        AddNewKeyAndValue();
                        break;
                    case "e":
                        AddValueToExistingKey();
                        break;
                    case "f":
                        SortKeys();
                        break;
                    case "x":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        static void PopulateDictionary()
        {
            dictionary.Clear();
            dictionary["Fruits"] = new List<string> { "Apple", "Banana", "Cherry" };
            dictionary["Colors"] = new List<string> { "Red", "Green", "Blue" };
            dictionary["Animals"] = new List<string> { "Cat", "Dog", "Elephant" };

            Console.WriteLine("Dictionary populated with sample data.");
        }

        static void DisplayDictionary()
        {
            if (dictionary.Count == 0)
            {
                Console.WriteLine("Dictionary is empty.");
                return;
            }

            Console.WriteLine("\nDisplaying dictionary contents:");

            // Enumeration method 1: foreach key-value pair
            Console.WriteLine("\nUsing foreach key-value pair:");
            foreach (var kvp in dictionary)
            {
                Console.WriteLine($"{kvp.Key}: {string.Join(", ", kvp.Value)}");
            }

            // Enumeration method 2: using Keys property
            Console.WriteLine("\nUsing Keys property:");
            foreach (var key in dictionary.Keys)
            {
                Console.WriteLine($"{key}: {string.Join(", ", dictionary[key])}");
            }

            // Enumeration method 3: using Values property
            Console.WriteLine("\nUsing Values property (keys not shown):");
            foreach (var values in dictionary.Values)
            {
                Console.WriteLine(string.Join(", ", values));
            }
        }

        static void RemoveKey()
        {
            Console.Write("Enter the key to remove: ");
            string key = Console.ReadLine();

            if (dictionary.Remove(key))
            {
                Console.WriteLine($"Key '{key}' removed.");
            }
            else
            {
                Console.WriteLine($"Key '{key}' not found.");
            }
        }

        static void AddNewKeyAndValue()
        {
            Console.Write("Enter new key: ");
            string key = Console.ReadLine();

            if (dictionary.ContainsKey(key))
            {
                Console.WriteLine("Key already exists.");
                return;
            }

            Console.Write("Enter value for the key: ");
            string value = Console.ReadLine();

            dictionary[key] = new List<string> { value };
            Console.WriteLine($"Added key '{key}' with value '{value}'.");
        }

        static void AddValueToExistingKey()
        {
            Console.Write("Enter existing key: ");
            string key = Console.ReadLine();

            if (!dictionary.ContainsKey(key))
            {
                Console.WriteLine("Key does not exist.");
                return;
            }

            Console.Write("Enter value to add: ");
            string value = Console.ReadLine();

            dictionary[key].Add(value);
            Console.WriteLine($"Added value '{value}' to key '{key}'.");
        }

        static void SortKeys()
        {
            if (dictionary.Count == 0)
            {
                Console.WriteLine("Dictionary is empty.");
                return;
            }

            var sortedKeys = dictionary.Keys.OrderBy(k => k).ToList();

            Console.WriteLine("\nKeys sorted in ascending order:");
            foreach (var key in sortedKeys)
            {
                Console.WriteLine($"{key}: {string.Join(", ", dictionary[key])}");
            }
        }
    }
}