namespace _01.AdvertisementMessage
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<string> phrasesList = new List<string>()
            {   
                "Excellent product.", "Such a great product.",
                "I always use that product.", "Best product of its category.",
                "Exceptional product.", "I can't live without this product."
            };

            List<string> eventsList = new List<string>()
            { 
                "Now I feel good.", "I have succeeded with this product.",
                "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.",
                "Try it yourself, I am very satisfied.", "I feel great!"
            };

            List<string> authorsList = new List<string>()
            {
                "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva"
            };

            List<string> citiesList = new List<string>()
            {
                "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse"
            };

            int inputNumber = int.Parse(Console.ReadLine());

            for (int i = 1; i <= inputNumber; i++)
            {
                Random number = new Random();

                int numberPhrase = number.Next(0, phrasesList.Count - 1);
                int numberEvents = number.Next(0, eventsList.Count - 1);
                int numberAuthor = number.Next(0, authorsList.Count - 1);
                int numberCity = number.Next(0, citiesList.Count - 1);


                Console.WriteLine($"{phrasesList[numberPhrase]} {eventsList[numberEvents]} {authorsList[numberAuthor]} – {citiesList[numberCity]}.");
            }
  




        }
    }
}
