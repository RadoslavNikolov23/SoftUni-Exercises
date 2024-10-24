using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        public Animal(string name, int age, string gender)
        {
            if (age < 0) throw new ArgumentException("Invalid input!");
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Invalid input!");
            if (string.IsNullOrWhiteSpace(gender)) throw new ArgumentException("Invalid input!");

            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }

        public abstract string ProduceSound();

        public override string ToString()
        {
            StringBuilder sbResult = new StringBuilder();
            sbResult.AppendLine($"{this.GetType().Name}");
            sbResult.AppendLine($"{this.Name} {this.Age} {this.Gender}");
            sbResult.Append(this.ProduceSound());
            return sbResult.ToString();
        }


    }
}
