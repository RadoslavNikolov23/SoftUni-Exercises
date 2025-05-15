using EDriveRent.Core.Contracts;
using EDriveRent.Models;
using EDriveRent.Models.Contracts;
using EDriveRent.Repositories;
using EDriveRent.Repositories.Contracts;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDriveRent.Core
{
    public class Controller : IController
    {
        private IRepository<IUser> users;
        private IRepository<IVehicle> vehicles;
        private IRepository<IRoute> routes;

        public Controller()
        {
            this.users = new UserRepository();
            this.vehicles = new VehicleRepository();
            this.routes = new RouteRepository();
        }

        public string RegisterUser(string firstName, string lastName, string drivingLicenseNumber)
        {
            IUser userToRegister = this.users.FindById(drivingLicenseNumber);
            if (userToRegister != null)
                return string.Format(OutputMessages.UserWithSameLicenseAlreadyAdded, drivingLicenseNumber);

            userToRegister = new User(firstName, lastName, drivingLicenseNumber);
            this.users.AddModel(userToRegister);
            return string.Format(OutputMessages.UserSuccessfullyAdded, firstName, lastName, drivingLicenseNumber);
        }

        public string UploadVehicle(string vehicleType, string brand, string model, string licensePlateNumber)
        {
            IVehicle vehicleToUpload = null;
            if (vehicleType == nameof(PassengerCar))
                vehicleToUpload = new PassengerCar(brand, model, licensePlateNumber);
            else if (vehicleType == nameof(CargoVan))
                vehicleToUpload = new CargoVan(brand, model, licensePlateNumber);
            else
                return string.Format(OutputMessages.VehicleTypeNotAccessible, vehicleType);

            IVehicle vehicleToFind = this.vehicles.FindById(licensePlateNumber);
            if (vehicleToFind != null)
                return string.Format(OutputMessages.LicensePlateExists, licensePlateNumber);

            this.vehicles.AddModel(vehicleToUpload);
            return string.Format(OutputMessages.VehicleAddedSuccessfully, brand, model, licensePlateNumber);
        }

        public string AllowRoute(string startPoint, string endPoint, double length)
        {
            IRoute routeToAllow = new Route(startPoint, endPoint, length, this.routes.GetAll().Count + 1);

            if(this.routes.GetAll().Any(r=>r.StartPoint==routeToAllow.StartPoint 
            && r.EndPoint==routeToAllow.EndPoint && r.Length==routeToAllow.Length))
                return string.Format(OutputMessages.RouteExisting,startPoint, endPoint, length);

            if (this.routes.GetAll().Any(r => r.StartPoint == routeToAllow.StartPoint
          && r.EndPoint == routeToAllow.EndPoint && r.Length < routeToAllow.Length))
                return string.Format(OutputMessages.RouteIsTooLong, startPoint, endPoint);

            IRoute routeWithLargeLenght = this.routes.GetAll().FirstOrDefault(r => r.StartPoint == routeToAllow.StartPoint&& r.EndPoint == routeToAllow.EndPoint && r.Length > routeToAllow.Length);

            if (routeWithLargeLenght != null)
                routeWithLargeLenght.LockRoute();

            this.routes.AddModel(routeToAllow);
            return string.Format(OutputMessages.NewRouteAdded, startPoint, endPoint, length);

        }

        public string MakeTrip(string drivingLicenseNumber, string licensePlateNumber, string routeId, bool isAccidentHappened)
        {

            IUser userToMakeTrip = this.users.FindById(drivingLicenseNumber);
            IVehicle vehicleToMakeTrip = this.vehicles.FindById(licensePlateNumber);
            IRoute routeToMakeTrip = this.routes.FindById(routeId);

            if (userToMakeTrip.IsBlocked)
                return string.Format(OutputMessages.UserBlocked, drivingLicenseNumber);

            if (vehicleToMakeTrip.IsDamaged)
                return string.Format(OutputMessages.VehicleDamaged, licensePlateNumber);

            if (routeToMakeTrip.IsLocked)
                return string.Format(OutputMessages.RouteLocked, routeId);

            vehicleToMakeTrip.Drive(routeToMakeTrip.Length);

            if (isAccidentHappened)
            {
                vehicleToMakeTrip.ChangeStatus();
                userToMakeTrip.DecreaseRating();
            }
            else
                userToMakeTrip.IncreaseRating();

           return vehicleToMakeTrip.ToString().Trim();
        }

        public string RepairVehicles(int count)
        {
            IVehicle[] damageVehicles = this.vehicles.GetAll().Where(v => v.IsDamaged == true).ToArray();

            int countToReduce = count;
            int countRepairCars = 0;
            foreach (IVehicle vehicle in damageVehicles.OrderBy(v => v.Brand)
                .ThenBy(v => v.Model))
            {
                if (countToReduce == 0) break;
                vehicle.ChangeStatus();
                vehicle.Recharge();
                countToReduce--;
                countRepairCars++;
            }
            return string.Format(OutputMessages.RepairedVehicles, countRepairCars);
        }

        public string UsersReport()
        {
            StringBuilder sb=new StringBuilder();

            sb.AppendLine("*** E-Drive-Rent ***");
            
            foreach(IUser user in this.users.GetAll().OrderByDescending(u=>u.Rating)
                .ThenBy(u=>u.LastName).ThenBy(u=>u.FirstName))
            {
                sb.AppendLine(user.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
