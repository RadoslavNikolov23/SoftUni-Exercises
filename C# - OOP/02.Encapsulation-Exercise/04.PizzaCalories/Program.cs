namespace PizzaCalories
{
    public class Program
    {
        public static void Main()
        {
            try
            {
                Pizza pizza = null;

                string input = Console.ReadLine();
                while (input != "END")
                {
                    string[] data = input.Split();

                    if (data[0] == "Pizza")
                    {
                        string pizzaName = data[1];
                        pizza = new Pizza(pizzaName);

                    }
                    else if (data[0] == "Dough")
                    {
                        string flourName = data[1];
                        string bakingTechique = data[2];
                        double doughGrams = double.Parse(data[3]);

                        pizza.DoughtPizza = new Dough(flourName.ToLower(), bakingTechique.ToLower(), doughGrams);
                    }
                    else if (data[0] == "Topping")
                    {
                        string toppingType = data[1];
                        double toppingGrams = double.Parse(data[2]);

                        Toppings topping = new Toppings(toppingType, toppingGrams);
                        pizza.AddToppings(topping);
                    }

                    input = Console.ReadLine();

                }
                Console.WriteLine(pizza);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
