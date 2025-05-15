using System.Text;

namespace CocktailBar
{
    public class Menu
    {
        public Menu(int barCapacity)
        {
            Cocktails = new List<Cocktail>();
            BarCapacity = barCapacity;
        }

        public List<Cocktail> Cocktails { get; set; }
        public int BarCapacity { get; set; }

        public void AddCocktail(Cocktail cocktail)
        {
            if (BarCapacity > Cocktails.Count)
            {
                if (!Cocktails.Any(x => x.Name == cocktail.Name)) Cocktails.Add(cocktail);
            }
        }

        public bool RemoveCocktail(string name)
        {
            if (!Cocktails.Any(x => x.Name == name)) return false;

            return Cocktails.Remove(this.Cocktails.First(x => x.Name == name));

        }

        public Cocktail GetMostDiverse()
        {
            return Cocktails.OrderByDescending(x => x.Ingredients.Count).First();
        }

        public string Details(string cocktailName)
        {
            int indexAt = Cocktails.FindIndex(x => x.Name == cocktailName);
            Cocktail cocktail = Cocktails[indexAt];

            return cocktail.ToString().Trim();
        }

        public string GetAll()
        {
            StringBuilder sbResult = new StringBuilder();
            sbResult.AppendLine("All Cocktails:");
            foreach (var cocktail in Cocktails.OrderBy(x => x.Name))
                sbResult.AppendLine(cocktail.Name);

            return sbResult.ToString().Trim();
        }
    }
}
