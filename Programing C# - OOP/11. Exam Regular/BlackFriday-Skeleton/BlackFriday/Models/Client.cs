using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFriday.Models
{
    public class Client : User
    {
        private const bool hasDataAccessClient = false;
        private Dictionary<string, bool> purchases;
        public Client(string userName, string email) : base(userName, email, hasDataAccessClient) => this.purchases = new Dictionary<string, bool>();

        public IReadOnlyDictionary<string, bool> Purchases { get => new ReadOnlyDictionary<string, bool>(this.purchases); }
        public override bool HasDataAccess { get => false;}

        public void PurchaseProduct(string productName, bool blackFridayFlag) => this.purchases[productName] = blackFridayFlag;

    }
}
