namespace _01.RapidCourier;

public class Program
{
    static void Main()
    {

        Stack<int> packages = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)); 
        
        Queue<int> couriers = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse));

        int totalWeigth = 0;

        while(packages.Count > 0 && couriers.Count > 0)
        {
            int lastPackage=packages.Pop();
            int firstCourier=couriers.Dequeue();

            if (firstCourier >= lastPackage)
            {
                int remaingCourierCapacity = firstCourier - (lastPackage * 2);

                if(remaingCourierCapacity > 0)
                {
                    couriers.Enqueue(remaingCourierCapacity);
                }

                totalWeigth+= lastPackage;
            }
            else
            {
                int remainingPackage = lastPackage - firstCourier;
               totalWeigth += lastPackage- remainingPackage;
                
                packages.Push(remainingPackage);
            }

        }

        Console.WriteLine($"Total weight: {totalWeigth} kg");
        if (packages.Count == 0 && couriers.Count == 0)
        {
            Console.WriteLine($"Congratulations, all packages were delivered successfully by the couriers today.");
        }
        else if(packages.Count != 0 && couriers.Count == 0)
        {
            Console.WriteLine($" Unfortunately, there are no more available couriers to deliver the following packages: {string.Join(", ", packages)}");
        }
        else
        {
            Console.WriteLine($"Couriers are still on duty: {string.Join(", ", couriers)} but there are no more packages to deliver.");
        }

    }
}
