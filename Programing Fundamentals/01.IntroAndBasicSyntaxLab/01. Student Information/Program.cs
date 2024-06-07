namespace _01._Student_Information
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string studentName=Console.ReadLine();
            int age=int.Parse(Console.ReadLine());
            decimal avarageGrade=decimal.Parse(Console.ReadLine());

            Console.WriteLine($"Name: {studentName}, Age: {age}, Grade: {avarageGrade}");


        }
    }
}
