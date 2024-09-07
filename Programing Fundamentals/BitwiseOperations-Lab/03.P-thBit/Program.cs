namespace _03.P_thBit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int atPositon = int.Parse(Console.ReadLine());

            Console.WriteLine((num >> atPositon) & 1);

        }
    }
}
