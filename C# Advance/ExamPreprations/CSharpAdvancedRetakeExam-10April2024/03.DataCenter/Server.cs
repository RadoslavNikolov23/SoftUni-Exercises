using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace DataCenter
{
    public class Server
    {
        public Server(string serialNumber, string model, int capacity, int powerUsage)
        {
            SerialNumber = serialNumber;
            Model = model;
            Capacity = capacity;
            PowerUsage = powerUsage;
        }

        public string SerialNumber { get; set; }
        public string Model { get; set; }
        public int Capacity { get; set; }
        public int PowerUsage { get; set; }

        public override string ToString()
        {
             StringBuilder sbResult = new StringBuilder();
            sbResult.AppendLine($"Server {this.SerialNumber}: {this.Model}, {this.Capacity}TB, {this.PowerUsage}W");

            return sbResult.ToString().Trim();
        }
    }
}
