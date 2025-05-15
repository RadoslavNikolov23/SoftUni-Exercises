namespace Stealer
{
    public class StartUp
    {
        static void Main()
        {

            Spy spy= new Spy();
           // string result = spy.StealFieldInfo("Stealer.Hacker", "username", "password");
            string result1 = spy.AnalyzeAccessModifiers("Stealer.Hacker");
            Console.WriteLine(result1);
        }
    }
}
