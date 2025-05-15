using System.Text;

namespace _05.Digits_LettersAndOthers
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string text = Console.ReadLine();

            string allLetters=String.Empty;
            string allDigits=String.Empty;
            string allOthers=String.Empty;

            for (int i = 0; i < text.Length; i++)
            {
                char newTemp = text[i];

                if (char.IsDigit(newTemp))
                {
                    allDigits += newTemp;
                }
                else if (char.IsLetter(newTemp))
                {
                    allLetters += newTemp;
                }
                else
                {
                    allOthers += newTemp;
                }
            }

            Console.WriteLine(allDigits);
            Console.WriteLine(allLetters);
            Console.WriteLine(allOthers);
        }
    }
}
