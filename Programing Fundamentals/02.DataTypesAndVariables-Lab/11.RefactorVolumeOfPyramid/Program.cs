


Console.Write("Length: ");
var lenght = double.Parse(Console.ReadLine());

Console.Write("Width: ");
var wight = double.Parse(Console.ReadLine());

Console.Write("Height: ");
var height = double.Parse(Console.ReadLine());

height = (lenght * wight * height) / 3;

Console.Write($"Pyramid Volume: {height:f2}");
