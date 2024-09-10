namespace _05.PrintEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] arrayNumbers=Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            Queue<int> queueNUmbers=new Queue<int>(arrayNumbers);
            List<int> finalList=new List<int>();

            while (queueNUmbers.Count > 0)
            {
                int tempNUmber=queueNUmbers.Dequeue();

                if (tempNUmber % 2 == 0)
                {
                    finalList.Add(tempNUmber);
                }
            }

            Console.Write(string.Join(", ",finalList));
        }
    }
}
