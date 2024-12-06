using BankLoan.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Repositories
{
    public class BankRepository : Repository<IBank>
    {
        public override IBank FirstModel(string name) => this.models.FirstOrDefault(b => b.Name == name);
    }
}
