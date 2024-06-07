string[] array=Console.ReadLine().Split().ToArray();
string[] newArray=new string[array.Length];

for (int i = 0; i < array.Length; i++)
{
    newArray[array.Length - 1-i] = array[i]; 

}

foreach (string s in newArray)
    Console.Write(s+" ");