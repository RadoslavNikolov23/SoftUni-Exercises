using MilitaryElite.Soldiers.Interfaces;
using MilitaryElite.Soldiers.SpecialisedSoliders;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MilitaryElite.Soldiers
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        private Dictionary<string, State> codeNameByState;
        public Commando(string id, string firstName, string lastName, decimal salary, Corps corps, Dictionary<string, State> codeNameByState) : base(id, firstName, lastName, salary, corps)
        {
            this.codeNameByState = codeNameByState;
        }

        public IReadOnlyDictionary<string, State> CodeNameByState { get => new ReadOnlyDictionary<string, State>(codeNameByState); }

        public override string ToString()
        {
            StringBuilder sbResult = new StringBuilder();
            sbResult.AppendLine($"{base.ToString()}");

            sbResult.AppendLine("Missions:");
            if(this.codeNameByState.Count > 0)
            {
                foreach (var missions in this.codeNameByState)
                {
                    sbResult.AppendLine($"  Code Name: {missions.Key} State: {missions.Value.ToString()}");
                }
            }
            return sbResult.ToString().Trim();
        }
    }
}
