namespace _02.Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //    •	2.00 – 2.99 - ""
            //    •	3.00 – 3.49 - ""
            //    •	3.50 – 4.49 - ""
            //    •	4.50 – 5.49 - ""
            //    •	5.50 – 6.00 - ""

            double grade = double.Parse(Console.ReadLine());

            CheckGrade(grade);

            void CheckGrade(double grade)
            {
                if (grade >= 5.50)
                {
                    Console.WriteLine("Excellent");
                }
                else if(grade >=4.50)
                {
                    Console.WriteLine("Very good");
                } 
                else if(grade >=3.50)
                {
                    Console.WriteLine("Good");
                } 
                else if(grade >=3.00)
                {
                    Console.WriteLine("Poor");
                }
                else
                {
                    Console.WriteLine("Fail");
                }
            }

        }
    }
}
