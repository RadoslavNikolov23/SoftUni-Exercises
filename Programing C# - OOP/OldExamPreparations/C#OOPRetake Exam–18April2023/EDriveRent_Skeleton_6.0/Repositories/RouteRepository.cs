using EDriveRent.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Repositories
{
    public class RouteRepository : Repository<IRoute>
    {
        public override IRoute FindById(string identifier) => this.GetAll().FirstOrDefault(r => r.RouteId == int.Parse(identifier));
    }
}
