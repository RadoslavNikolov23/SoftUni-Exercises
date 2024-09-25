using System.IO;

namespace EvenLines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            using (StreamReader textReader = new StreamReader(inputFilePath))
            {
                StringBuilder sbOutput= new StringBuilder();

                string text = textReader.ReadLine();
                int cout = 0;

                while (text != null)
                {
                    if (cout % 2 == 0)
                    {
                        text = SymbolsReplace(text);
                        sbOutput.Append($"{text} \n");
                        
                        
                    }
                    cout++;
                    text = textReader.ReadLine();

                   


                }

                return sbOutput.ToString();
            }

        }

        public static string SymbolsReplace(string text)
        {
            char[] sumbols = new char[] { '-', ',', '.', '!', '?' };
            string newText = string.Empty;
            

            for (int i = 0; i < text.Length; i++)
            {
                char temp = text[i];
                if (sumbols.Contains(temp))
                {
                    newText += '@';
                }
                else
                {
                    newText += temp;
                }

            }

            string[] arrayText = newText.Split(' ',StringSplitOptions.RemoveEmptyEntries);
            Array.Reverse(arrayText);

            newText= string.Empty;
            foreach(string word in arrayText)
            {
                newText += $"{word} ";
            }

          

            return newText;

                    /*
                     * replace {'-', ', ', '. ', '! ', '? '} with '@' 
                     * and reverse the order of the words.
                     */
        }
    }
}
