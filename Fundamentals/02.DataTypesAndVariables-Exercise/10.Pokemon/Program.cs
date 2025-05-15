using System.Numerics;

BigInteger pokePowerN = int.Parse(Console.ReadLine());
BigInteger distanceM = int.Parse(Console.ReadLine());
BigInteger exhFactorY = int.Parse(Console.ReadLine());
int counter = 0;
BigInteger originalPokePowerN = pokePowerN;

while (distanceM <= pokePowerN)
{
    counter++;
    pokePowerN  -= distanceM;

    if (originalPokePowerN / 2 == pokePowerN && exhFactorY!=0)
    {
        pokePowerN /= exhFactorY;
    }

  }
    Console.WriteLine(pokePowerN);
    Console.WriteLine(counter);
