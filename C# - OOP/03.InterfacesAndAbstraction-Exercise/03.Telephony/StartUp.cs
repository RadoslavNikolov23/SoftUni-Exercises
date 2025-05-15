namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            string[] phoneNUmbers = Console.ReadLine().Split(" ");
            string[] webSites = Console.ReadLine().Split(" ");


            Smartphone smartPhone = new Smartphone();
            StationaryPhone stationaryPhone = new StationaryPhone();

            foreach(string phone in phoneNUmbers)
            {
                if(checkIfValidPhone(phone)) Console.WriteLine("Invalid number!");
                else if (phone.Length == 7) Console.WriteLine(stationaryPhone.Call(phone));
                else if (phone.Length == 10) Console.WriteLine(smartPhone.Call(phone));
            }       
            
            foreach(string website in webSites)
            {
                if(checkIfValidWebSite(website)) Console.WriteLine("Invalid URL!");
                else Console.WriteLine(smartPhone.Browse(website));
            }
        }

        private static bool checkIfValidPhone(string phone) => phone.Any(x=>!char.IsDigit(x));
        private static bool checkIfValidWebSite(string website) => website.Any(x=>char.IsDigit(x));
         
        
    }
}
