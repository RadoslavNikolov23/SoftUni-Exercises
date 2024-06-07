using System.Numerics;

int numberBall = int.Parse(Console.ReadLine());
BigInteger bestBall = 0;
BigInteger bestSnow = 0;
BigInteger bestTime = 0;
BigInteger bestQuality = 0;

for (int i = 0; i < numberBall; i++)
{
    int snow=int.Parse(Console.ReadLine());
    int time=int.Parse(Console.ReadLine());
    int quality=int.Parse(Console.ReadLine());

    BigInteger currBall = BigInteger.Pow((snow / time), quality);

    if(currBall > bestBall)
    {
        bestBall=currBall; 
        bestSnow=snow; 
        bestTime=time; 
        bestQuality=quality;   

    }

}
Console.WriteLine($"{bestSnow} : {bestTime} = {bestBall} ({bestQuality})");