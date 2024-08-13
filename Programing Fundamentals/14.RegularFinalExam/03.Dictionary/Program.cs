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
                string[] wordsSplit = wordsAndDefinitaion[i].Split(":");
                if (wordDictionary.ContainsKey(wordsSplit[0]))
                {
                    wordDictionary[wordsSplit[0]].Add(wordsSplit[1]);
                }
                else
                {
                    wordDictionary.Add(wordsSplit[0], new List<string> {wordsSplit[1]});
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

            }


        }

        public static void PrintWordAndDefiniton(KeyValuePair<string, List<string>> word)
        {
            StringBuilder definitionBuilder = new StringBuilder();
            
            foreach (var definiton in word.Value)
            {
                definitionBuilder.Append($"-{definiton}\n");
            }

            //•	If the command is "Test", you should find each word that your teacher will test you on
            //(if it exists in your notebook) and print all its definitions in the following format:
            
            StringBuilder outputBuilder= new StringBuilder();
            //outputBuilder.Append($"{word.Key}\n"
            //                     +$" -{word.Value.ForEach(def=>def.))}");
           
            
            //"{word}:"
            //" -{definition1}"
            //" -{definition2}"
            //    …
            //" -{definitionN}"

        }
    }
}
