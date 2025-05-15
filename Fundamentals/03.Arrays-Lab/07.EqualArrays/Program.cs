using System;

int[] array1=Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
int[] array2=Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
int sum = 0;
int countSum = 0;


if (array1.Length == array2.Length)
{
	for (int i = 0; i < array1.Length; i++)
	{
		if (array1[i] == array2[i])
		{
			countSum++;
        }
		else
		{
            Console.WriteLine($"Arrays are not identical. Found difference at {i} index");
			break;
        }
	}
    
}


if (countSum == array1.Length)
{
	for (int i = 0;i < array1.Length; i++)
	{
        sum += array1[i];

    }
    Console.WriteLine($"Arrays are identical. Sum: {sum}");
}




