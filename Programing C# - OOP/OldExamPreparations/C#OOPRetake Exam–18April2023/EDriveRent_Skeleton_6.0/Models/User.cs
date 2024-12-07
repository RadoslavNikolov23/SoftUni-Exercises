using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Models
{
    public class User : IUser
    {
        public User(string firstName, string lastName, string drivingLicenseNumber)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException(ExceptionMessages.FirstNameNull);

            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException(ExceptionMessages.LastNameNull);

            if (string.IsNullOrWhiteSpace(drivingLicenseNumber))
                throw new ArgumentException(ExceptionMessages.DrivingLicenseRequired);

            this.FirstName = firstName;
            this.LastName = lastName;
            this.DrivingLicenseNumber = drivingLicenseNumber;
            this.Rating = 0;
            this.IsBlocked = false;
        }

        public string FirstName { get; }
        public string LastName { get; }
        public double Rating { get; private set; }
        public string DrivingLicenseNumber { get; }
        public bool IsBlocked { get; private set; }

        public void IncreaseRating()
        {
            
            if (this.Rating < 10)
                this.Rating += 0.5;
        }

        public void DecreaseRating()
        {
            
            if (this.Rating < 2)
            {
                this.Rating = 0;
                this.IsBlocked = true;
            }
            else
                this.Rating -= 2;
        }

        public override string ToString() => $"{this.FirstName} {this.LastName} Driving license: {this.DrivingLicenseNumber} Rating: {this.Rating}";


    }
}
