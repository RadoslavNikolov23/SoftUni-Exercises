using _03.GenericScale;

namespace GenericScale
{
    public class StartUp
    {
        static void Main()
        {
            EqualityScale<int> list = new EqualityScale<int>(5,5);

            Console.WriteLine(list.AreEqual());

        }
    }
}
