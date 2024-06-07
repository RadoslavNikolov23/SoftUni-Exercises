char sumb1 = char.Parse(Console.ReadLine());
char sumb2 = char.Parse(Console.ReadLine());
char sumb3 = char.Parse(Console.ReadLine());

char[] sumb = {sumb1, sumb2, sumb3};
Array.Reverse(sumb);

foreach (char newSumb in sumb)
{
    Console.Write(newSumb + " ");
}
