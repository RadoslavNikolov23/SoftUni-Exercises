namespace _07.AppendArrays
{
    internal class Program
    {
        
        static void Main(string[] args)
        {

            string input = Console.ReadLine();
            
      

            List<string> arrayInput = input.Split("|").ToList();

            List<string[]> arrayInput2 = arrayInput.Select(x=>x.Split(" ")).ToList();



            arrayInput2.Reverse();

            Console.WriteLine(string.Join(" ", arrayInput2));


        }

       
    }
}
