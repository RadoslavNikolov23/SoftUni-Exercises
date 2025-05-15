using System.Text;

namespace _01.StringManipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            sb.Append(input);

            string commands;
            while ((commands = Console.ReadLine()) != "End")
            {
                string[] arrayCommand = commands.Split();
                string firstCommand = arrayCommand[0];

                switch (firstCommand)
                {
                    case "Translate":
                        char translateChar = char.Parse(arrayCommand[1]);
                        char translateReplacemnt = char.Parse(arrayCommand[2]);
                        sb.Replace(translateChar, translateReplacemnt);
                        Console.WriteLine(sb);
                        break;

                    case "Includes":
                        string includeSubstring = arrayCommand[1];
                        Console.WriteLine(sb.ToString().Contains(includeSubstring));
                        break;

                    case "Start":
                        string startSubstring = arrayCommand[1];
                        Console.WriteLine(sb.ToString().StartsWith(startSubstring));
                        break;

                    case "Lowercase":
                        string newSB = sb.ToString().ToLower();
                        sb.Clear().Append(newSB);
                        Console.WriteLine(sb);
                        break;

                    case "FindIndex":
                        char findIndexChar = char.Parse(arrayCommand[1]);
                        Console.WriteLine(sb.ToString().LastIndexOf(findIndexChar));
                        break;

                    case "Remove":
                        int removeStarIndex = int.Parse(arrayCommand[1]);
                        int removeCount=int.Parse(arrayCommand[2]);
                        sb.Remove(removeStarIndex, removeCount);
                        Console.WriteLine(sb);
                        break;
                }




             
      
                




            }
        }
    }
}
