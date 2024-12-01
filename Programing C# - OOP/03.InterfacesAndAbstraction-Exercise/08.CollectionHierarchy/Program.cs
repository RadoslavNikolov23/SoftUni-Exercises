namespace CollectionHierarchy
{
    public class Program
    {
        static void Main()
        {

            string[] input = Console.ReadLine().Split(" ");


            IMyList myList = new MyList();
            IMyList myListAdd = new AddCollection();
            IMyList myListAddRemove = new AddRemoveCollection();

            int numberOfOperations=int.Parse(Console.ReadLine());

            int[] operatinMyList = new int[input.Length];
            int[] operatinMyListAdd = new int[input.Length];
            int[] operatinMyListAddRemove = new int[input.Length];

            for(int i = 0; i < input.Length; i++)
            {
                operatinMyListAdd[i]=myListAdd.Add(input[i]);
                operatinMyListAddRemove[i] = myListAddRemove.Add(input[i]);
                operatinMyList[i] = myList.Add(input[i]);
            }

            string[] removeAtMyList = new string[numberOfOperations];
            string[] removeAtMyListAddRemove = new string[numberOfOperations];

            for (int i = 0; i < numberOfOperations; i++)
            {
                myListAdd.Remove();
                removeAtMyListAddRemove[i]=myListAddRemove.Remove();
                removeAtMyList[i]=myList.Remove();
            }

            Console.WriteLine(string.Join(" ",operatinMyListAdd));
            Console.WriteLine(string.Join(" ",operatinMyListAddRemove));
            Console.WriteLine(string.Join(" ",operatinMyList));     
            
            Console.WriteLine(string.Join(" ",removeAtMyListAddRemove));
            Console.WriteLine(string.Join(" ",removeAtMyList));



        }
    }
}
