using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models
{
    public class TeamLead : TeamMember
    {
        private string[] pathTeamLead = new string[] { "Master" };
       
        public TeamLead(string name, string path) : base(name, path)
        {
            if (!pathTeamLead.Contains(path))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.PathIncorrect,path));
            }
        }

        public override string ToString()
        {
            return $"{this.Name} ({this.GetType().Name}) - " + base.ToString();
        }
    }
}
