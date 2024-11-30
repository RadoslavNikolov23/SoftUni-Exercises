using MilitaryElite.Soldiers.Interfaces;
using MilitaryElite.Soldiers.SpecialisedSoliders;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Soldiers
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private Dictionary<string, int> repairsByHours;
        public Engineer(string id, string firstName, string lastName, decimal salary, Corps corps, Dictionary<string, int> repairsByHours) : base(id, firstName, lastName, salary, corps)
        {
            this.repairsByHours = repairsByHours;
        }

        public IReadOnlyDictionary<string, int> RepairsByHours { get => new ReadOnlyDictionary<string, int>(repairsByHours); }

        public override string ToString()
        {
            StringBuilder sbResult = new StringBuilder();
            sbResult.AppendLine($"{base.ToString()}");

            sbResult.AppendLine("Repairs:");
            foreach (var reapair in this.repairsByHours)
            {
                sbResult.AppendLine($"  Part Name: {reapair.Key} Hours Worked: {reapair.Value}");
            }

            return sbResult.ToString().Trim();

        }
    }
}
