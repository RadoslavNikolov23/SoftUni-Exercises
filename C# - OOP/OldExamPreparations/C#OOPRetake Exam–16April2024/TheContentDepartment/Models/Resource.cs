using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Utilities.Messages;

namespace TheContentDepartment.Models
{
    public abstract class Resource : IResource
    {

        protected Resource(string name, string creator, int priority)
        {
            if(string.IsNullOrWhiteSpace(name)) 
                throw new ArgumentNullException(ExceptionMessages.NameNullOrWhiteSpace);

            this.Name = name;
            this.Creator = creator;
            this.Priority = priority;
            this.IsTested = false;
            this.IsApproved = false;
        }

        public string Name { get; }
        public string Creator { get; }
        public int Priority { get;  }
        public bool IsTested { get; private set; }
        public bool IsApproved { get; private set; }

        public void Approve()
        {
            this.IsApproved= true;
        }

        public void Test()
        {
            this.IsTested = !this.IsTested;
        }

        public override string ToString()
        {
            return $"{this.Name} ({this.GetType().Name}), Created By: {this.Creator}";
        }
    }
}
