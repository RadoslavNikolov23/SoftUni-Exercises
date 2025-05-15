using BlackFriday.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFriday.Repositories
{
    public class UserRepository : Repository<IUser>
    {
        public override bool Exists(string name) => this.Models.Any(u => u.UserName == name);

        public override IUser GetByName(string name) => this.Models.FirstOrDefault(u => u.UserName == name);
    }
}
