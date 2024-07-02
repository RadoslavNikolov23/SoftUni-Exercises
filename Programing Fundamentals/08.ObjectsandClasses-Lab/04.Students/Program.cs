namespace _04.Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> studentList = new List<Student>();
            string input;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] arrayInput = input.Split();
                string firstName = arrayInput[0];
                string lastName = arrayInput[1];
                string age = arrayInput[2];
                string homeTown = arrayInput[3];

                Student studen = new Student();
                studen.firstName = firstName;
                studen.lastName= lastName;
                studen.age= age;
                studen.homeTown= homeTown;

                studentList.Add(studen);
            }

            input=Console.ReadLine();
            foreach (var student in studentList)
            {
                if (student.homeTown == input)
                {
                    Console.WriteLine($"{student.firstName} {student.lastName} is {student.age} years old.");
                }
                
            }


        }

        class Student
        {
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string age { get; set; }
            public string homeTown { get; set; }


        }
    }
}
