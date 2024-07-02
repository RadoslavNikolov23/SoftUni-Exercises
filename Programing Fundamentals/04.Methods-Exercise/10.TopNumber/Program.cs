namespace _10.TopNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int endNumber = int.Parse(Console.ReadLine());

            for (int i = 1; i <= endNumber; i++)
            {
                if (CheckForDivisibBy8(i))
                {
                    if (CheckOddDigit(i))
                    {
                        Console.WriteLine(i);
                    }
                }
            }
        }
        static bool CheckOddDigit(int i)
        {        //Holds at least one odd digit, e.g. 232, 707, 87578
            string digitsString = i.ToString();
            int sumDigits = 0;
            for (int j = 0; j < digitsString.Length; j++)
            {
                if (digitsString[j] % 2 == 0)
                {
                    continue;
                }
                else
                {
                    return true;
                }
            }

            return false;

        }
        static bool CheckForDivisibBy8(int i)
        {            //Its sum of digits is divisible by 8, e.g. 8, 17, 88
            string digitsString = i.ToString();
            int sumDigits = 0;
            for (int j = 0; j < digitsString.Length; j++)
            {
                sumDigits += digitsString[j];
            }

           
            if (sumDigits % 8 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
 

