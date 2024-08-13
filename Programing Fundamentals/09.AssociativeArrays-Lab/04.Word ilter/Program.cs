

string[] array=Console.ReadLine()
    .Split()
    .ToArray();

array=array.Where(word=>word.Length%2==0).ToArray();

Console.WriteLine(string.Join(Environment.NewLine, array));