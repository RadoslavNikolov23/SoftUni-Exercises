using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models
{
    public class MortgageLoan : Loan
    {
        private const int interestRateMortgageLoan = 3;
        private const double amountRateMortgageLoan = 50000;
        public MortgageLoan() : base(interestRateMortgageLoan, amountRateMortgageLoan)
        {
        }
    }
}
