namespace _02.AverageStudentGrades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfStudents=int.Parse(Console.ReadLine());

            Dictionary<string,List<decimal>> studensDictionary = new Dictionary<string,List<decimal>>();

            for (int i = 0; i < numberOfStudents; i++)
            {
                string[]array=Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string nameStudent=array[0];
                decimal studentGrade = decimal.Parse(array[1]);

                if (!studensDictionary.ContainsKey(nameStudent))
                {
                    studensDictionary.Add(nameStudent, new List<decimal>());
                }

                studensDictionary[nameStudent].Add(studentGrade);
            }

            foreach (var student in studensDictionary)
            {
                decimal avarage =student.Value.Average();
              
                Console.WriteLine($"{student.Key} -> {string.Join(" ",student.Value.Select(x=>$"{x:f2}"))} (avg: {avarage:f2})");

            }

        }
    }
}
