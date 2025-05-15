using BankLoan.Core.Contracts;
using BankLoan.Models;
using BankLoan.Models.Contracts;
using BankLoan.Repositories;
using BankLoan.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BankLoan.Core
{
    public class Controller : IController
    {
        private LoanRepository loans;
        private BankRepository banks;

        public Controller()
        {
            this.loans = new LoanRepository();
            this.banks = new BankRepository();
        }
        public string AddBank(string bankTypeName, string name)
        {
            IBank bank = null;
            if (bankTypeName == nameof(BranchBank))
                bank = new BranchBank(name);
            else if (bankTypeName == nameof(CentralBank))
                bank = new CentralBank(name);
            else
                throw new ArgumentException(ExceptionMessages.BankTypeInvalid);

            this.banks.AddModel(bank);
            return string.Format(OutputMessages.BankSuccessfullyAdded, bankTypeName);
        }

        public string AddLoan(string loanTypeName)
        {
            ILoan loan = null;
            if (loanTypeName == nameof(StudentLoan))
                loan = new StudentLoan();
            else if (loanTypeName == nameof(MortgageLoan))
                loan = new MortgageLoan();
            else
                throw new ArgumentException(ExceptionMessages.LoanTypeInvalid);

            this.loans.AddModel(loan);
            return string.Format(OutputMessages.LoanSuccessfullyAdded, loanTypeName);

        }

        public string ReturnLoan(string bankName, string loanTypeName)
        {
            ILoan loanToReturn = this.loans.FirstModel(loanTypeName);
            if (loanToReturn == null)
                throw new ArgumentException(string.Format(ExceptionMessages.MissingLoanFromType, loanTypeName));


            IBank bankToRegisterLoan = this.banks.FirstModel(bankName);
            bankToRegisterLoan.AddLoan(loanToReturn);
            this.loans.RemoveModel(loanToReturn);
            return string.Format(OutputMessages.LoanReturnedSuccessfully, loanTypeName, bankName);

        }

        public string AddClient(string bankName, string clientTypeName, string clientName, string id, double income)
        {
            IClient client = null;
            if (clientTypeName == nameof(Student))
                client = new Student(clientName, id, income);
            else if (clientTypeName == nameof(Adult))
                client = new Adult(clientName, id, income);
            else
                throw new ArgumentException(ExceptionMessages.ClientTypeInvalid);

            IBank bankToRegister = this.banks.FirstModel(bankName);

            string bankTypeName = bankToRegister.GetType().Name;

            if (clientTypeName == nameof(Student) && bankTypeName == nameof(BranchBank))
            {
                bankToRegister.AddClient(client);
                return string.Format(OutputMessages.ClientAddedSuccessfully, clientTypeName, bankName);
            }
            else if (clientTypeName == nameof(Adult) && bankTypeName == nameof(CentralBank))
            {
                bankToRegister.AddClient(client);
                return string.Format(OutputMessages.ClientAddedSuccessfully, clientTypeName, bankName);
            }
            else
                return string.Format(OutputMessages.UnsuitableBank);

        }

        public string FinalCalculation(string bankName)
        {
            IBank bank = this.banks.FirstModel(bankName);
            double incomes = bank.Clients.Sum(c => c.Income);
            double loans = bank.Loans.Sum(l => l.Amount);
            return string.Format(OutputMessages.BankFundsCalculated, bankName, string.Format($"{incomes + loans:f2}"));
        }

        public string Statistics()
        {
            StringBuilder sb = new StringBuilder();
            foreach(IBank bank in this.banks.Models)
            {
                sb.AppendLine(bank.GetStatistics());
            }
            return sb.ToString().Trim();
        }
    }
}
