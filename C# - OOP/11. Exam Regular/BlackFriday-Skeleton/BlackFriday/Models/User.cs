using BlackFriday.Models.Contracts;
using BlackFriday.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFriday.Models
{
    public abstract class User : IUser
    {
        private string userName;
        private string email;
        public User(string userName, string email, bool hasDataAccess)
        {
            UserName = userName;
            Email = email;
        }

        public string UserName
        {
            get => userName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.UserNameRequired);

                userName = value;
            }
        }
        public abstract bool HasDataAccess { get; }
        public string Email
        {
            get
            {
                if (this.HasDataAccess)
                    return "hidden";
                else
                    return email;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException(ExceptionMessages.EmailRequired);

                email = value;
            }
        }

        public override string ToString()
        {
            string userType = HasDataAccess ? "Admin" : "Client";
            return $"{this.UserName} - Status: {userType}, Contact Info: {this.Email}";
        }
    }
}
