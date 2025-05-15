using HighwayToPeak.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighwayToPeak.Models
{
    public class BaseCamp : IBaseCamp
    {
        private SortedSet<string> residents;

        public BaseCamp()
        {
            this.residents = new SortedSet<string>();
        }
        public IReadOnlyCollection<string> Residents { get => this.residents.ToList().AsReadOnly(); }

        public void ArriveAtCamp(string climberName)
        {
            this.residents.Add(climberName);
        }

        public void LeaveCamp(string climberName)
        {
            this.residents.Remove(climberName);
        }
    }
}
