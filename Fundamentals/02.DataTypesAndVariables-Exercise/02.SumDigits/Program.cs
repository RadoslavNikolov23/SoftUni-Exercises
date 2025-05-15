int number = int.Parse(Console.ReadLine());
int finalNumber = 0;


while (number > 0) 
{
    finalNumber += number % 10;
    number /= 10;

  
}
Console.WriteLine(finalNumber);