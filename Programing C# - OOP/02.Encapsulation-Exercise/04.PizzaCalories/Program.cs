namespace PizzaCalories
{
    public class Program
    {
        public static void Main()
        {
            try
            {

                string input = Console.ReadLine();
                string[] data = input.Split(" ");

                string pizzaName = data[1];

                input = Console.ReadLine();
                data = input.Split(" ");
                string flourName = data[1];
                string bakingTechique = data[2];
                double doughGrams = double.Parse(data[3]);

                Dough dough = new Dough(flourName, bakingTechique, doughGrams);
                Pizza pizza = new Pizza(pizzaName, dough);

                Pizza pizzaOne= new Pizza(pizzaName,dough);


                input = Console.ReadLine();
                while (input != "END")
                {
                    string[] toppings = input.Split(" ");
                    string toppingTpe = toppings[1];
                    double toppingGrams = double.Parse(toppings[2]);

                    Toppings topping = new Toppings(toppingTpe, toppingGrams);
                    pizza.AddToppings(topping);
                   
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
