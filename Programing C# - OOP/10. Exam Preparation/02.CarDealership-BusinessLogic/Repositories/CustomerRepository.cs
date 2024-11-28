using CarDealership.Models;
using CarDealership.Models.Contracts;
using CarDealership.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Repositories
{
    public class CustomerRepository : IRepository<ICustomer>
    {
        private List<ICustomer> customers;
        public CustomerRepository()
        {
            this.customers = new List<ICustomer>();
        }
        public IReadOnlyCollection<ICustomer> Models { get => this.customers.AsReadOnly(); }

        public void Add(ICustomer model)
        {
            this.customers.Add(model);
        }

        public bool Remove(string text)
        {
            ICustomer customer = this.customers.FirstOrDefault(c=>c.Name == text);
            return this.customers.Remove(customer);
        }

        public bool Exists(string text)
        {
            return this.customers.Any(c => c.Name == text);
        }

        public ICustomer Get(string text)
        {
            return this.customers.FirstOrDefault(c => c.Name == text);
        }

       
    }
}
