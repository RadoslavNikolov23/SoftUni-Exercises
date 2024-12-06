using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models
{
    public class StudentLoan : Loan
    {
        private const int interestRateStudenLoan = 1;
        private const double amountRateStudenLoan = 10000;
        public StudentLoan() : base(interestRateStudenLoan, amountRateStudenLoan)
        {
        }
    }
}
