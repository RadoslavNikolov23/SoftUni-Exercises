using System.Text;

namespace CocktailBar
{
    public class Cocktail
    {
        public Cocktail(string ingredients)
        {
            this.ingredients = ingredients.Split(", ").ToList();
        }
        public Cocktail(string name, decimal price, double volume, string ingredients):this(ingredients)
        {
            this.Name = name;
            this.Price = price;
            this.Volume = volume;
          
        }

        private List<string> ingredients;


        public string Name { get; set; }
        public decimal Price { get; set; }
        public double Volume { get; set; }
        public List<string> Ingredients { get => ingredients; }

        public override string ToString()
        {
            StringBuilder sbResult= new StringBuilder();
            sbResult.AppendLine($"{this.Name}, Price: {this.Price:F2} BGN, Volume: {this.Volume} ml");
            sbResult.AppendLine($"Ingredients: {string.Join(", ", this.ingredients)}");


            //Long Island, Price: 13.00 BGN, Volume: 300 ml
            //Ingredients:  Vodka, Tequilla, White Rum, Cointreau, Gin, Lemon Juice, Cola

            return sbResult.ToString().Trim();
        }
    }
}
