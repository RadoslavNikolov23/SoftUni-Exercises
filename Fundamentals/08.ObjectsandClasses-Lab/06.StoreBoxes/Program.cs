namespace _06.StoreBoxes
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string input;
            List<Box> boxList=new List<Box>();

            while ((input = Console.ReadLine()) != "end")
            {
                string[] inputArra = input.Split();
                string serialNumber = inputArra[0];
                string itemName = inputArra[1];
                int quantity = int.Parse(inputArra[2]);
                double itemPrice = double.Parse(inputArra[3]);
                //"{Serial Number} {Item Name} {Item Quantity} {itemPrice}"

                Box box = new Box();
                box.SerialNumber=serialNumber;
                box.Item = new Item(){Name=itemName,Price=itemPrice};
                box.ItemQuantity=quantity;
                box.PriceForABox=quantity*itemPrice;

                boxList.Add(box);
            }


            List<Box> sortetBoxList=new List<Box>();
            sortetBoxList=boxList
                .OrderBy(x=>x.PriceForABox)
                .ToList();

            sortetBoxList.Reverse();
           
            foreach (var box in sortetBoxList)
            {
                Console.WriteLine($"{box.SerialNumber}");
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:f2}: {box.ItemQuantity}");
                Console.WriteLine($"-- ${box.PriceForABox:f2}");
            }


        }

        class Item
        {
            public string Name { get; set; }
            public double Price { get; set; }
        }

        class Box
        {
           
            public string SerialNumber { get; set; }
            public Item Item { get; set; }
            public int ItemQuantity { get; set; }
            public double PriceForABox { get; set; }
        }
    }
}
