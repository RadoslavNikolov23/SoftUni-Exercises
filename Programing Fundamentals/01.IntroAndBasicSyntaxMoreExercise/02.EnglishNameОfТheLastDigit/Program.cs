int number = int.Parse(Console.ReadLine());


int lastNumber = number % 10;
string lastDigit=string.Empty;

switch (lastNumber)
{
	case 0:
        lastDigit = "zero";
        break;
	case 1:
        lastDigit = "one";
        break;
	case 2:
        lastDigit = "two";
        break;
	case 3:
        lastDigit = "three";
        break;
	case 4:
        lastDigit = "four";
        break;
	case 5:
        lastDigit = "five";
        break;
	case 6:
        lastDigit = "six";
        break;
	case 7:
        lastDigit = "seven";
        break;
	case 8:
        lastDigit = "eight";
        break;
	case 9:
        lastDigit = "nine";
        break;

}
Console.WriteLine(lastDigit);


