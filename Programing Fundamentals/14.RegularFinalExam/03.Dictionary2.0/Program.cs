using System.Collections.Generic;
using System;
using System.Text;

namespace _03.Dictionary
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Dictionary<string, List<string>> wordDictionary = new Dictionary<string, List<string>>();

            string[] wordsAndDefinitaion = Console.ReadLine().Split(" | ");

            for (int i = 0; i < wordsAndDefinitaion.Length; i++)
            {
                string[] wordsSplit = wordsAndDefinitaion[i].Split(":",StringSplitOptions.TrimEntries);
                if (wordDictionary.ContainsKey(wordsSplit[0]))
                {
                    wordDictionary[wordsSplit[0]].Add(wordsSplit[1]);
                }
                else
                {
                    wordDictionary.Add(wordsSplit[0], new List<string> { wordsSplit[1] });
                }
            }

            string[] wordsToTest = Console.ReadLine().Split(" | ");

            string command = Console.ReadLine();

            if (command == "Test")
            {
                for (int i = 0; i < wordsToTest.Length; i++)
                {
                    foreach (var word in wordDictionary)
                    {
                        if (word.Key.Contains(wordsToTest[i]))
                        {
                            PrintWordAndDefiniton(word);
                        }
                    }
                }
            }
            else if (command == "Hand Over")
            {

                List<string> wordList = new List<string>();

                foreach (var word in wordDictionary)
                {
                    wordList.Add($"{word.Key}");
                }

                Console.WriteLine($"{string.Join(" ",wordList)}");
            }


        }

        public static void PrintWordAndDefiniton(KeyValuePair<string, List<string>> word)
        {
            List<string> definitionList = new List<string>();

            foreach (var definiton in word.Value)
            {
                definitionList.Add($"-{definiton}");
            }

            Console.WriteLine($"{word.Key}:");
            foreach (var definition in definitionList)
            {
                Console.WriteLine($" {definition}");
            }
         

        }
    }
}
