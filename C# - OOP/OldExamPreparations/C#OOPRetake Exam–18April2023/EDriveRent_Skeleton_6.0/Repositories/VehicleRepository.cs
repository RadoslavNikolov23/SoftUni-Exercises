using EDriveRent.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Repositories
{
    public class VehicleRepository : Repository<IVehicle>
    {
        public override IVehicle FindById(string identifier) => this.GetAll().FirstOrDefault(v=>v.LicensePlateNumber == identifier);
    }
}
