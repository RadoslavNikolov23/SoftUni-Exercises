using BankLoan.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Repositories
{
    public class LoanRepository : Repository<ILoan>
    {
        public override ILoan FirstModel(string name) => this.Models.FirstOrDefault(m => m.GetType().Name == name);
    }
}
