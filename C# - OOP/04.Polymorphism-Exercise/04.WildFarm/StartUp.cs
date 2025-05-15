using System.Buffers;
using WildFarm.AnimalsClasses;
using WildFarm.FoodClasses;
using WildFarm.Interfaces;

namespace WildFarm
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();


            while (true)
            {
                string inputEven = Console.ReadLine();
                if (inputEven == "End") break;

                string inputOdd = Console.ReadLine();


                Animal animal = AddToAnimals(inputEven);
                Food food = FoodType(inputOdd);

                animal.ProduceSoundForFood(food);

                animals.Add(animal);


            }

            foreach (Animal animal in animals)
                Console.WriteLine(animal.ToString());
        }

        private static Food FoodType(string? inputOdd)
        {
            string[] data = inputOdd.Split(" ");
            string foodType = data[0];
            int foodQuality = int.Parse(data[1]);

            switch (foodType)
            {
                case "Vegetable":
                    return new Vegetable(foodQuality);
                case "Fruit":
                    return new Fruit(foodQuality);
                case "Meat":
                    return new Meat(foodQuality);
                case "Seeds":
                    return new Seeds(foodQuality);
                default: throw new ArgumentException("Invalid type animal!");
            }
        }

        private static Animal AddToAnimals(string? inputEven)
        {
            string[] data = inputEven.Split(" ");
            string typeAnimal = data[0];
            string animalName = data[1];
            double animalWeight = double.Parse(data[2]);

            switch (typeAnimal)
            {
                case "Owl":
                    double wingSizeOwn = double.Parse(data[3]);
                    return new Owl(animalName, animalWeight, wingSizeOwn);
                case "Hen":
                    double wingSizeHen = double.Parse(data[3]);
                    return new Hen(animalName, animalWeight, wingSizeHen);
                case "Dog":
                    string livingRegionDog = data[3];
                    return new Dog(animalName, animalWeight, livingRegionDog);
                case "Mouse":
                    string livingRegionMouse = data[3];
                    return new Mouse(animalName, animalWeight, livingRegionMouse);
                case "Cat":
                    string livingRegionCat = data[3];
                    string breedCat = data[4];
                    return new Cat(animalName, animalWeight, livingRegionCat, breedCat);
                case "Tiger":
                    string livingRegionTiger = data[3];
                    string breedTiger = data[4];
                    return new Tiger(animalName, animalWeight, livingRegionTiger, breedTiger);
                default: throw new ArgumentException("Invalid type animal!");
            }

        }
    }
}
