namespace _02.ChangeList
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Create a program, that reads a list of integers from the console and receives commands to manipulate the list.
            //    Your program may receive the following commands:
            //    •	Delete { element} – delete all elements in the array, which are equal to the given element.
            //    •	Insert { element} { position} – insert the element at the given position.
            //    You should exit the program when you receive the "end" command.Print all numbers in the array, separated by a single whitespace.

            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            string command;

            while ((command = Console.ReadLine()) != "end")
            {
                List<string> commandList = new List<string>(command.Split());

                if (commandList[0] == "Delete")
                {
                    int number = int.Parse(commandList[1]);
                    list.RemoveAll(x=>x==number);
                }
                else if (commandList[0] == "Insert")
                {
                    list.Insert(int.Parse(commandList[2]), int.Parse(commandList[1]));
                }
            }

            Console.WriteLine(string.Join(" ",list));



        }
    }
}
