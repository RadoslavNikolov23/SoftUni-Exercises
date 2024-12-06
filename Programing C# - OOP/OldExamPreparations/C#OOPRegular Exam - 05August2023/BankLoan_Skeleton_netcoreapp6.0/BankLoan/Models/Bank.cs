using BankLoan.Models.Contracts;
using BankLoan.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models
{
    public abstract class Bank : IBank
    {
        private List<ILoan> loans;
        private List<IClient> clients;  
        protected Bank(string name, int capacity)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(ExceptionMessages.BankNameNullOrWhiteSpace);

            Name = name;
            Capacity = capacity;
            loans=new List<ILoan>();
            clients=new List<IClient>();
        }

        public string Name { get; }
        public int Capacity { get; }
        public IReadOnlyCollection<ILoan> Loans { get => this.loans.AsReadOnly(); }
        public IReadOnlyCollection<IClient> Clients { get=>this.clients.AsReadOnly(); }

        public double SumRates()
        {
            double sum=this.loans.Sum(i=>i.InterestRate);
            return sum;
        }

        public void AddClient(IClient Client)
        {
            if (Capacity > this.clients.Count)
            {
                this.clients.Add(Client);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.NotEnoughCapacity);
            }

        }

        public void RemoveClient(IClient Client) => this.clients.Remove(Client);

        public void AddLoan(ILoan loan) => this.loans.Add(loan);

        public string GetStatistics()
        {
            StringBuilder sb=new StringBuilder();

            sb.AppendLine($"Name: {this.Name}, Type: {this.GetType().Name}");
            if(this.clients.Count > 0)
            {
                sb.AppendLine($"Clients: {string.Join(", ",this.clients)}");
            }
            else
            {
                sb.AppendLine($"Clients: none");
            }
            sb.AppendLine($"Loans: {this.Loans.Count}, Sum of Rates: {SumRates}");

            /*
             * "
Clients: {clientName1}, {clientName2} ... / Clients: none


             */

            return sb.ToString().Trim();
        }

     

      
    }
}
