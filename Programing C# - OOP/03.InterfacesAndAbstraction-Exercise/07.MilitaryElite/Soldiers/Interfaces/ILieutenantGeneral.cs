using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Soldiers.Interfaces
{
    public interface ILieutenantGeneral:IPrivate
    {
        public IReadOnlyCollection<IPrivate> Privates { get; }
    }
}
