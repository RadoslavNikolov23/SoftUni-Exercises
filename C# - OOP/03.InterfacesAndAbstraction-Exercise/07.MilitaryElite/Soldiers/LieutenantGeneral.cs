using MilitaryElite.Soldiers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryElite.Soldiers
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private List<IPrivate> privates;
        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary, List<IPrivate>privates) : base(id, firstName, lastName, salary)
        {
            this.privates = privates;
        }

        public IReadOnlyCollection<IPrivate> Privates { get => this.privates.AsReadOnly(); }

        public override string ToString()
        {
            StringBuilder sbResult= new StringBuilder();
            sbResult.AppendLine($"{base.ToString()}");
            sbResult.AppendLine("Privates:");
            foreach (IPrivate priv in this.privates)
            {
                sbResult.AppendLine($"  {priv.ToString()}");
            }

            return sbResult.ToString().Trim();

        }
    }
}
