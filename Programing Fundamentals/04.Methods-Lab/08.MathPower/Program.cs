namespace _08.MathPower
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //•	The first number – the base
            //    •	The second number – the power
            //The method should return the base raised to the given power.

            double firstNumber= double.Parse(Console.ReadLine());
            double secondNumber = double.Parse(Console.ReadLine());

            Console.WriteLine(ResultPower(firstNumber,secondNumber));

            static double ResultPower(double number, double power)
            {
                return Math.Pow(number, power);
            }




        }
    }
}
