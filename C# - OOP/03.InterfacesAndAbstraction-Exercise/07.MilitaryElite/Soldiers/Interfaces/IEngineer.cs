using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Soldiers.Interfaces
{
    public interface IEngineer:ISpecialisedSoldier
    {
        public IReadOnlyDictionary<string,int> RepairsByHours {  get; } //name of the part and hours worked
    }
}
