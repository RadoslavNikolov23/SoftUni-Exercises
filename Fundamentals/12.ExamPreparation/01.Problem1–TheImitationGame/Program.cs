using System.Text;

namespace _01.Problem1_TheImitationGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string encryptedMessage = Console.ReadLine();
            StringBuilder message= new StringBuilder(encryptedMessage);

            string input;
            while ((input = Console.ReadLine()) != "Decode")
            {
                string[] array=input.Split('|');
                string command = array[0];

                switch (command)
                {
                    case "Move":
                        int moveNumebrLetters = int.Parse(array[1]);
                        string tempMess = string.Empty;
                        for (int i = 0; i < moveNumebrLetters; i++)
                        {
                            tempMess += message[i];
                        }
                        
                        message.Remove(0, moveNumebrLetters);
                        message.Append(tempMess);
                        break;

                    case "Insert":
                        int indexOfInsert = int.Parse(array[1]);
                        string valuOfInsert = array[2];
                        message.Insert(indexOfInsert, valuOfInsert);
                        break;

                    case "ChangeAll":
                        string oldText= array[1];
                        string replamentText= array[2];
                        message.Replace(oldText, replamentText);
                        break;
                }

            }
            Console.WriteLine($"The decrypted message is: {message}");

        }
    }
}
