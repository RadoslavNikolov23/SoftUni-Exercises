using EDriveRent.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Repositories
{
    public class UserRepository : Repository<IUser>
    {
        public override IUser FindById(string identifier) => this.collection.FirstOrDefault(u => u.DrivingLicenseNumber == identifier);
    }
}
