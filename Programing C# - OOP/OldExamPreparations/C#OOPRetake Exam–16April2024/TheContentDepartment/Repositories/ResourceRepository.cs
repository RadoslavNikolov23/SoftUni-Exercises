using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheContentDepartment.Models.Contracts;
using TheContentDepartment.Repositories.Contracts;

namespace TheContentDepartment.Repositories
{
    public class ResourceRepository : IRepository<IResource>
    {
        private List<IResource> models;
        public ResourceRepository()
        {
            models = new List<IResource>();
        }
        public IReadOnlyCollection<IResource> Models { get => this.models.AsReadOnly(); }

        public void Add(IResource model)
        {
            this.models.Add(model);
        }

        public IResource TakeOne(string modelName)
        {
            return this.models.FirstOrDefault(m => m.Name == modelName);
        }
    }
}
