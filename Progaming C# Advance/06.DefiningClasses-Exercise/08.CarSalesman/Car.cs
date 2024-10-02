using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    public class Car
    {
        public Car(string model, Engine engine, int? weight=null, string? color=null)
        {
            Model = model;
            Engine = engine;
            Weight = weight;
            Color = color;
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int? Weight { get; set; }
        public string? Color { get; set; }

        public override string ToString()
        {
            StringBuilder sbResult = new StringBuilder();
            sbResult.AppendLine($"{Model}:");
            sbResult.AppendLine($" {Engine.ToString()}");
            sbResult.AppendLine($"  Weight: {Weight?.ToString() ?? "n/a"}");
            sbResult.Append($"  Color: {Color ?? "n/a"}");

            return sbResult.ToString().Trim();
        }
        

    }
}
