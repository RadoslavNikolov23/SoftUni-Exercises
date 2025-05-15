using MilitaryElite.Soldiers.SpecialisedSoliders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Soldiers.Interfaces
{
    public interface ICommando:ISpecialisedSoldier
    {
        public IReadOnlyDictionary<string, State> CodeNameByState { get; } //InProgress / Finished
    }
}
