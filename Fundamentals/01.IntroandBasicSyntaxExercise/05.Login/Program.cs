namespace _05.Login
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string user = Console.ReadLine();
            string reversePassword = string.Empty;
            for (int i = user.Length - 1; i >= 0; i--)
            {
                reversePassword += user[i];
            }

            string password = string.Empty;

            bool passTrue = true;
            int count = 0;

            while (passTrue)
            {
                password = Console.ReadLine();
                

                if (password == reversePassword)
                {
                    Console.WriteLine($"User {user} logged in.");
                    passTrue = false;
                }
                else
                {
                    count++;
                    if (count >= 4)
                    {
                        Console.WriteLine($"User {user} blocked!");
                        break;
                    }
                    Console.WriteLine("Incorrect password. Try again.");
                    
                }

                

            }




        }
    }
}
