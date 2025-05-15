using System;

namespace RandomSentencesGenerator
{
    class RandomSentencesGenarator
    {
        static void Main(string[] args)
        {
            string[] names = { "Peter", "Michell", "Jane", "Steve", "Jacob", "John", "Bob", "Amanda", "Linda" };
            string[] places = { "Sofia", "Plovdiv", "Varna", "Burgas", "Russe", "Haskovo", "Blagoevgrad", "Paris", "London", "Madrid" };
            string[] verbs = { "eats", "holds", "sees", "plays with", "brings", "goes", "walkes" };
            string[] nouns = { "stones", "cake", "apple", "laptop", "bikes", "cars", "food", "bed" };
            string[] adverbs = { "slowly", "diligently", "warmly", "sadly", "rapidly", "badly", "quickly", "rarely" };
            string[] details = { "near the river", "at home", "in the park", "at work", "on the streets", "in the pub", "at the store" };

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Hello, Welcome to the Random-Generator Sentence Project. Enjoy it! \n");
            Console.ForegroundColor = ConsoleColor.White;
            while (true)
            {
                string randomName = GetRandomWord(names);
                string randomPlace = GetRandomWord(places);
                string randomVerb = GetRandomWord(verbs);
                string randomNoun = GetRandomWord(nouns);
                string randomAdverb = GetRandomWord(adverbs);
                string randomDetail = GetRandomWord(details);

                string who = $"{randomName} from {randomPlace}";
                string action = $"{randomAdverb} {randomVerb} the {randomNoun}";
                string sentence = $"{who} {action} {randomDetail}.";

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(sentence);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Click [Enter] to genarte a new one.");
                Console.ReadLine();
            }
        }

        static string GetRandomWord(string[] words)
        {
            Random random = new Random();
            int randomIndex = random.Next(words.Length);
            string word = words[randomIndex];
            return word;
        }
    }
}
