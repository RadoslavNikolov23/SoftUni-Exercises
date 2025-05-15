using CarDealership.Models.Contracts;
using CarDealership.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Repositories
{
    public class VehicleRepository : IRepository<IVehicle>
    {
        private List<IVehicle> vehicles;
        public VehicleRepository()
        {
            this.vehicles = new List<IVehicle>();
        }
        public IReadOnlyCollection<IVehicle> Models { get => this.vehicles.AsReadOnly(); }

        public void Add(IVehicle model)
        {
            this.vehicles.Add(model);
        }

        public bool Remove(string text)
        {
            IVehicle vehicle = this.vehicles.FirstOrDefault(v => v.Model == text);
            return this.vehicles.Remove(vehicle);
        }

        public bool Exists(string text)
        {
            return this.vehicles.Any(v => v.Model == text);
        }

        public IVehicle Get(string text)
        {
            return this.vehicles.FirstOrDefault(v => v.Model == text);
        }

     
    }
}
