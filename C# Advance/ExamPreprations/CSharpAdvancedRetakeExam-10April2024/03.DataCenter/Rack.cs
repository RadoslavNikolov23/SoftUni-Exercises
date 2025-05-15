using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace DataCenter
{
    public class Rack
    {
        public Rack(int slots)
        {
            this.Slots = slots;
            this.Servers = new List<Server>();
        }
        public int Slots { get; set; }
        public List<Server> Servers { get; set; }
        public int GetCount { get { return Servers.Count; } }


        public void AddServer(Server server)
        {
            if (GetCount >= Slots) return;

            if (!this.Servers.Any(x => x.SerialNumber == server.SerialNumber)) Servers.Add(server);

        }

        public  bool RemoveServer(string serialNumber)
        {
            Server server = this.Servers.FirstOrDefault(x => x.SerialNumber == serialNumber);

            return Servers.Remove(server);
        }

        public string GetHighestPowerUsage()
        {
            Server server = this.Servers.OrderByDescending(x=>x.PowerUsage).First();
            return server.ToString();
        }

        public int GetTotalCapacity()
        {
            return Servers.Sum(x => x.Capacity);  //TODO??
        }

        public string DeviceManager()
        {
            StringBuilder sbResult = new StringBuilder();
            sbResult.AppendLine($"{this.GetCount} servers operating:");
            sbResult.AppendLine($"{string.Join("\n",Servers)}");

            return sbResult.ToString().Trim();
        }

    }
}
