int numberRow = int.Parse(Console.ReadLine());
string word = string.Empty;

for (int i = 0; i < numberRow; i++)
{
    string typeNumber = Console.ReadLine();

   // int number = int.Parse(typeNumber);

    if (typeNumber.Length >= 4)
    {
        switch (typeNumber)
        {
            case "7777":
                word += "s";
                break;
            case "9999":
                word += "z";
                break;
        }
    }

    else if (typeNumber.Length >= 3)
    {
        switch (typeNumber)
        {
            case "222":
                word += "c";
                break;
            case "333":
                word += "f";
                break;
            case "444":
                word += "i";
                break;
            case "555":
                word += "l";
                break;
            case "666":
                word += "o";
                break;
            case "777":
                word += "r";
                break;
            case "888":
                word += "v";
                break;
            case "999":
                word += "y";
                break;
        }
    }
    else if (typeNumber.Length >= 2)
    {
        switch (typeNumber)
        {
            case "22":
                word += "b";
                break;
            case "33":
                word += "e";
                break;
            case "44":
                word += "h";
                break;
            case "55":
                word += "k";
                break;
            case "66":
                word += "n";
                break;
            case "77":
                word += "q";
                break;
            case "88":
                word += "u";
                break;
            case "99":
                word += "x";
                break;
        }
    }
    else if(typeNumber.Length >= 1)
    {
        switch (typeNumber)
        {

            case "0":
                word += " ";
                break;
            case "2":
                word += "a";
                break;
            case "3":
                word += "d";
                break;
            case "4":
                word += "g";
                break;
            case "5":
                word += "j";
                break;
            case "6":
                word += "m";
                break;
            case "7":
                word += "p";
                break;
            case "8":
                word += "t";
                break;
            case "9":
                word += "w";
                break;
        }
    }

}
Console.WriteLine(word);