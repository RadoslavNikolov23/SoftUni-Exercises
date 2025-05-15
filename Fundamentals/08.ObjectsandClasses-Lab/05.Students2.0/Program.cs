namespace _05.Students2._0
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
                int age = int.Parse(arrayInput[2]);
                string city = arrayInput[3];


                if (StudentExists(studentList, firstName, lastName))
                {
                    Student student=GetStudent(studentList, firstName, lastName);
                    student.FirstName = firstName;
                    student.LastName = lastName;
                    student.Age = age;
                    student.City = city;
                   // studentList.Add(student);
                }
                else
                {

                    Student student = new Student()
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        Age = age,
                        City = city
                    };

                    studentList.Add(student);


                }

            }
            input = Console.ReadLine();
            foreach (var student in studentList)
            {
                if (student.City == input)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }

            }

        }

        private static Student GetStudent(List<Student> studentList, string firstName, string lastName)
        {
            Student existiStudent = null;

            foreach (var student in studentList)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    existiStudent=student;
                }
            }

            return existiStudent;
        }

        private static bool StudentExists(List<Student> studentList, string firstName, string lastName)
        {
            foreach (var student in studentList)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    return true;

                }


            }
            return false;
        }


        class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public string City { get; set; }
        }
    }
}
