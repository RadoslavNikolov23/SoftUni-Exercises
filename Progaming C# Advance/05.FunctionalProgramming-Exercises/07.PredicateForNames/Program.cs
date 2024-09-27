namespace _07.PredicateForNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int namesLenght = int.Parse(Console.ReadLine());
            List<string> namesList = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            Predicate<string> isEnoughtLenght = x => x.Length <= namesLenght;

            foreach (string name in namesList)
            {
                if(isEnoughtLenght(name))
                    Console.WriteLine(name);
            }
        }
    }
}
