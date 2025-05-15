﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.ExplicitInterfaces
{
    public class Citizen : IPerson, IResident
    {
        public Citizen(string name, string country, int age )
        {
            Name = name;
            Country = country;
            Age = age;
        }

        public string Name { get; set; }
        public string Country { get; set; }
        public int Age { get; set; }

        public string GetName()
        {
            return ((IPerson)this).Name;
        }

        string IResident.GetName()
        {
            return $"Mr/Ms/Mrs {((IPerson)this).Name}";
        }
    }
}
