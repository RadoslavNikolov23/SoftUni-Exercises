using System.Runtime.CompilerServices;
using System.Text;

namespace GroceriesManagement
{
    public class GroceriesStore
    {
        public GroceriesStore(int capacity)
        {
            this.Capacity = capacity;
            this.Stall = new List<Product>();
            this.Turnover = 0;
        }
        public int Capacity { get; set; }
        public double Turnover { get; set; }
        public List<Product> Stall { get; set; }


        public void AddProduct(Product product)
        {
            if (this.Capacity == this.Stall.Count) return;

            if(!this.Stall.Any(x=>x.Name == product.Name)) this.Stall.Add(product);
 
        }

        public bool RemoveProduct(string name) => Stall.Remove(Stall.FirstOrDefault(x => x.Name == name));

        public string SellProduct(string name, double quantity)
        {
            if (!this.Stall.Any(x => x.Name == name)) return "Product not found";

            Product product=this.Stall.FirstOrDefault(x=>x.Name==name);
            double totalPrice = Math.Round(product.Price * quantity,2);
            this.Turnover += totalPrice;
            return $"{product.Name} - {totalPrice:F2}$";
        }

        public string GetMostExpensive() => this.Stall.OrderByDescending(x=> x.Price).FirstOrDefault().ToString();

        public string CashReport() => $"Total Turnover: {Turnover:F2}$";

        public string PriceList()
        {
            StringBuilder sbOutput= new StringBuilder();
            sbOutput.AppendLine($"Groceries Price List:");
            sbOutput.AppendLine($"{string.Join("\n",this.Stall)}");

            return sbOutput.ToString().Trim();
        }


    }
}
