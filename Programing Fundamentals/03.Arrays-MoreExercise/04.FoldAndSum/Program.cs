//int[] array=Console.ReadLine().Split().Select(int.Parse).ToArray();


//for (int row = 0; row < array.Length/4; row++)
//{
//    int sum1 = array[row] + array[row + array.Length / 4];
//    int sum2 = array[array.Length - 1] + array[array.Length-1-array.Length/4];

//    Console.Write(sum1+ " " + sum2);

//}

int[] mainArray={1,2,3,};

int[] array2=new int[3];

array2=mainArray;

array2[0]=-55;
array2[1]=-4;
array2[2]=5;
Console.WriteLine(string.Join(" ",mainArray));