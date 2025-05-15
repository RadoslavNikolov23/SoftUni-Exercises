
string input = Console.ReadLine();

char[] inputToChar=input.ToCharArray();
Array.Reverse(inputToChar);
string reverseInput = new string(inputToChar);
Console.WriteLine(reverseInput);

