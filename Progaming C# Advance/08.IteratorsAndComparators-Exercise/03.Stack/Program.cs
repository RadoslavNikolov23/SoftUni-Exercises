using System.Xml.Linq;

namespace Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputArray = Console.ReadLine().Split(new char [] { ' ', ',' },StringSplitOptions.RemoveEmptyEntries);

            Stack<int> stack = new Stack<int>(inputArray.Skip(1).Select(int.Parse).ToArray());

            inputArray = Console.ReadLine().Split(new char[] { ' ', ',' });

            while (inputArray[0] != "END")
            {
                switch (inputArray[0])
                {
                    case "Push":
                        stack.Push(int.Parse(inputArray[1]));
                        break;
                    case "Pop":
                        stack.Pop();
                        break;
                }

                inputArray = Console.ReadLine().Split(new char[] { ' ', ',' });
            }


            foreach (int element in stack)
            {
                Console.WriteLine(element);
            }  
            foreach (int element in stack)
            {
                Console.WriteLine(element);
            }
        
        }

     
    }
}
