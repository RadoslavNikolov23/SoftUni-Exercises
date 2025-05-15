using MilitaryElite.Soldiers.SpecialisedSoliders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Soldiers.Interfaces
{
    public interface ISpecialisedSoldier:IPrivate
    {
        public Corps Corps { get; }
    }
}
