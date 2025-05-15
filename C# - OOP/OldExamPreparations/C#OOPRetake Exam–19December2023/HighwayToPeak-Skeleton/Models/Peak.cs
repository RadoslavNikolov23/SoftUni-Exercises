﻿using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Models
{
    public class Peak : IPeak
    {
        public Peak(string name, int elevation, string difficultyLevel)
        {
            if(string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(ExceptionMessages.PeakNameNullOrWhiteSpace);

            if(elevation<=0)
                throw new ArgumentException(ExceptionMessages.PeakElevationNegative);

            this.Name = name;
            this.Elevation = elevation;
            this.DifficultyLevel = difficultyLevel;
        }

        public string Name { get; }
        public int Elevation { get; }
        public string DifficultyLevel { get; }

        public override string ToString()
        {
            return $"Peak: {this.Name} -> Elevation: {this.Elevation}, Difficulty: {this.DifficultyLevel}";
        }
    }
}
