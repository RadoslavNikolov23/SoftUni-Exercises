int number = int.Parse(Console.ReadLine());


int start = (char)('a');
int end = (char)('a') + number;

for (int i = start; i < end; i++)
{
    for (int j = start; j < end; j++)
    {
        for (int k = start; k < end; k++)
        {

            Console.WriteLine($"{(char)i}{(char)j}{(char)k}");


        }

    }
}