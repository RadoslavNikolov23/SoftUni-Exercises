using System.Threading.Channels;

namespace _03.CharactersInRange
{
    internal class Program
    {
        static void Main(string[] args)
        {

            char sumbolOne = char.Parse(Console.ReadLine());
            char sumbolTwo = char.Parse(Console.ReadLine());

           PrintCharInRange(sumbolOne, sumbolTwo);


          
        }

         static void PrintCharInRange(char sumbolOne, char sumbolTwo)
         {
             string output=null;

             if (sumbolOne > sumbolTwo)
             {
                 char tempSumn=sumbolOne;
                 sumbolOne=sumbolTwo;
                 sumbolTwo= tempSumn;
             }

            for (int i = sumbolOne+1; i < sumbolTwo; i++)
            {
                // output += (char)i + " ";
                Console.Write((char)i + " ");

            }

            //Console.WriteLine(output.TrimEnd(' '));


        }
    }
}
