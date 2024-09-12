namespace _11.KeyRevolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int priceForBullet=int.Parse(Console.ReadLine());
            int sizeOfGunBarrel=int.Parse(Console.ReadLine());
            Stack<int> stackBullets = new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse));
            Queue<int> queueLocks = new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse));
            int valueOfGoods = int.Parse(Console.ReadLine());

            int counterBangs = 0;
            int bulletsOrigin=stackBullets.Count;

            while (true ) 
            {
                int bulletTemp =stackBullets.Peek();
                int lockTemp = queueLocks.Peek();

                if (bulletTemp <= lockTemp) 
                {
                    Console.WriteLine("Bang!");
                    stackBullets.Pop();
                    queueLocks.Dequeue();
                    counterBangs++;
                }
                else
                {
                    Console.WriteLine("Ping!");
                    stackBullets.Pop();
                    counterBangs++;
                }

                if (counterBangs >= sizeOfGunBarrel && stackBullets.Count>0)
                {
                    Console.WriteLine("Reloading");
                    counterBangs=0;
                }

                if(stackBullets.Count == 0 || queueLocks.Count == 0) break;
            }

            if (stackBullets.Count == 0 && queueLocks.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {queueLocks.Count}");
            }
            else
            {
                int moneyEarned= valueOfGoods-((bulletsOrigin-stackBullets.Count)*priceForBullet);
                Console.WriteLine($"{stackBullets.Count} bullets left. Earned ${moneyEarned}");
            }

            /*
             * •	 If Sam runs out of bullets before the safe runs out of locks, print
               "Couldn't get through. Locks left: {locksLeft}".
               •	If Sam manages to open the safe, print
               "{bulletsLeft} bullets left. Earned ${moneyEarned}".
               
             */

        }
    }
}
