using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models
{
    public abstract class TeamMember : ITeamMember
    {
        private List<string> inProgress;
        protected TeamMember(string name, string path)
        {
            if(string.IsNullOrWhiteSpace(name)) 
                throw new ArgumentException(ExceptionMessages.NameNullOrWhiteSpace);

            Name = name;
            Path = path;
            inProgress= new List<string>();
        }

        public string Name { get; }
        public string Path { get; protected set; }
        public IReadOnlyCollection<string> InProgress { get=> this.inProgress.AsReadOnly(); }

        public void WorkOnTask(string resourceName)
        {
            this.inProgress.Add(resourceName);
        }

        public void FinishTask(string resourceName)
        {
            this.inProgress.Remove(resourceName);
        }

        public override string ToString()
        {
            return $"Currently working on {this.InProgress.Count} tasks.";
        }


    }
}
