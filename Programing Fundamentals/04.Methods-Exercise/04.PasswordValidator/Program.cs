namespace _04.PasswordValidator
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string password = Console.ReadLine();

            bool checkLeght = CheckLengtPassword(password);
            bool checkLetandDig = CheckLetterDigitPassword(password);
            bool checkForDigit = CheckForDigitstPassword(password);

            if (!checkLeght)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
            if (!checkLetandDig)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }
            if (!checkForDigit)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }

            if (checkForDigit && checkLeght && checkLetandDig)
            {
                Console.WriteLine("Password is valid");
            }
            

        }

         static bool CheckForDigitstPassword(string password)
         {
             int coun = 0;
             for (int i = 0; i < password.Length; i++)
             {
                 if (password[i] >= 48 && password[i] <= 57)
                 {
                     coun++;
                     if (coun >= 2)
                     {
                         return true;
                     }
                 }
                 else
                 {
                     continue;
                 }
             }

             return false;
         }

        static bool CheckLetterDigitPassword(string password)
        {
            for (int i = 0; i < password.Length; i++)
            {
                if ((password[i] >= 65 && password[i] <= 90) || (password[i] >= 97 && password[i] <= 122) || (password[i] >= 48 && password[i] <= 57))
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }

            return true;

        }

        static bool CheckLengtPassword(string password)
        {
            if (password.Length < 6 || password.Length > 10)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
