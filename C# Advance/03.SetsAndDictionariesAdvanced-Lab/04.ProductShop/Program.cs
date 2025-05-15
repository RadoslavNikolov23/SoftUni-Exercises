namespace _04.ProductShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> shopList = new Dictionary<string, Dictionary<string, double>>();

            string input;

            while ((input = Console.ReadLine()) != "Revision")
            {
                string[] inputArray=input.Split(", ",StringSplitOptions.RemoveEmptyEntries);
                string shopName=inputArray[0];
                string productName=inputArray[1];
                double priceProduct=double.Parse(inputArray[2]);

                if(!shopList.ContainsKey(shopName))
                {
                    shopList.Add(shopName,new Dictionary<string, double>());
                }

                if (!shopList[shopName].ContainsKey(productName))
                {
                    shopList[shopName][productName] = priceProduct;
                }
            }

            foreach (var shops in shopList.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{shops.Key}->");
                foreach (var productPrice in shops.Value)
                {
                Console.WriteLine($"Product: {productPrice.Key}, Price: {productPrice.Value}");
                    
                }
            }

        }
    }
}
