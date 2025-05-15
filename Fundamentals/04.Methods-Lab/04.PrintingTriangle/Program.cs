namespace _04.PrintingTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1
            //1 2
            //1 2 3
            //1 2
            //1

            int number = int.Parse(Console.ReadLine());

            FirstHalf(number);
            SecondHalf(number);
            void FirstHalf(int n)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j <= i; j++)
                    {
                        Console.Write(j + 1 + " ");
                    }

                    Console.WriteLine();
                    
                }
            }
            
            void SecondHalf(int n)
            {
                for (int i = n-1; i > 0; i--)
                {
                    for (int j = 0; j < i; j++)
                    {
                        Console.Write(j + 1 + " ");
                    }

                    Console.WriteLine();
                    
                }
            }

        }
    }
}
