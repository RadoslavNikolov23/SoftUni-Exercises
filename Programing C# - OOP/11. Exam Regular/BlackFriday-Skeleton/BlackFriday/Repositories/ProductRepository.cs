using BlackFriday.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFriday.Repositories
{
    public class ProductRepository : Repository<IProduct>
    {
        public override bool Exists(string name) => this.Models.Any(p => p.ProductName == name);

        public override IProduct GetByName(string name) => this.Models.FirstOrDefault(p => p.ProductName == name);
    }
}
