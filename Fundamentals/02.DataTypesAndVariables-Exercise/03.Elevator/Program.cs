int numberPeople = int.Parse(Console.ReadLine());
int capacityPeople = int.Parse(Console.ReadLine());

int courses = (int)Math.Ceiling((double)numberPeople/capacityPeople);

Console.WriteLine(courses);