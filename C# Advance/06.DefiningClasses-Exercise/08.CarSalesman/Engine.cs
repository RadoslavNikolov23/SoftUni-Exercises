using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace CarSalesman
{
    public class Engine
    {
        public Engine(string model, int power, int? displacement=null, string? efficiency=null)
        {
            Model = model;
            Power = power;
            Displacement = displacement;
            Efficiency = efficiency;
        }

        public string Model { get; set; }
        public int Power { get; set; }
        public int? Displacement { get; set; }
        public string? Efficiency { get; set; }


        public override string ToString()
        {
            StringBuilder sbResult = new StringBuilder();
            
            sbResult.AppendLine($"  {Model}:");
            sbResult.AppendLine($"    Power: {Power}");
            sbResult.AppendLine($"    Displacement: {Displacement?.ToString() ?? "n/a"}");
            sbResult.Append($"    Efficiency: {Efficiency ?? "n/a"}");
           

            return sbResult.ToString().Trim();
        }
    }
}
