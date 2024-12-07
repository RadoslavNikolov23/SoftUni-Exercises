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
        private double rating;
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

        //public double Rating { 
        //    get 
        //    {
        //        if (rating > 10.0)
        //            return 10.0;
        //        return rating;
        //    } 
        //    private set 
        //    {
        //        if (value > 10.0)
        //            rating= 10.0;
        //         rating=value;
        //    } 
        //}
        public string DrivingLicenseNumber { get; }
        public bool IsBlocked { get; private set; }

        public void IncreaseRating()
        {
            this.Rating += 0.5;
            if (this.Rating > 10.0)
                this.Rating = 10.0;
        }

        public void DecreaseRating()
        {
            this.Rating -= 2;
            if (this.Rating < 0)
            {
                this.Rating = 0;
                this.IsBlocked = true;
            }
        }

        public override string ToString() => $"{this.FirstName} {this.LastName} Driving license: {this.DrivingLicenseNumber} Rating: {this.Rating}";


    }
}
