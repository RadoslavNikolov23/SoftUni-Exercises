using BlackFriday.Models.Contracts;
using BlackFriday.Repositories;
using BlackFriday.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFriday.Models
{
    public class Application : IApplication
    {
        private IRepository<IProduct> products;
        private IRepository<IUser> users;

        public Application()
        {
            this.products = new ProductRepository();
            this.users = new UserRepository();
        }
        public IRepository<IProduct> Products { get => this.products; }
        public IRepository<IUser> Users { get => this.users; }
    }
}
