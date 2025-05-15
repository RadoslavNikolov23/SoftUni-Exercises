using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models
{
    public class ContentMember : TeamMember
    {
        private string[] pathTeamLead = new string[] { "CSharp", "JavaScript", "Python", "Java" };

        public ContentMember(string name, string path) : base(name, path)
        {
            if (!pathTeamLead.Contains(path))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.PathIncorrect, path));
            }
        }
        public override string ToString()
        {
            return $"{this.Name} - {this.Path} path. " + base.ToString();
        }
    }
}
