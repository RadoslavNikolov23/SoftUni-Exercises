using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace EstateAgency
{
    public class EstateAgency
    {
        public EstateAgency(int capacity)
        {
            Capacity = capacity;
            RealEstates=new List<RealEstate> ();
        }
        public List<RealEstate> RealEstates { get; set; }
        public int Capacity { get; set; }
        public int Count
        {
            get
            { return RealEstates.Count; }
        }

        public void AddRealEstate(RealEstate realEstate)
        {
            if (Capacity > Count)
            {
                if(!RealEstates.Any(x=>x.Address== realEstate.Address))
                         RealEstates.Add(realEstate);
            }
        }

        public bool RemoveRealEstate(string address)
        {
            int indexAt=RealEstates.FindIndex(x=>x.Address== address);

            if (indexAt == -1) return false;

            RealEstates.RemoveAt(indexAt);
            return true;

        }

        public List<RealEstate> GetRealEstates(string postalCode)
        {
            return RealEstates.Where(x => x.PostalCode == postalCode).ToList();
        }

        public RealEstate GetCheapest()
        {
            RealEstate cheapestRealEstate = RealEstates.OrderBy(x=>x.Price).First();
            return cheapestRealEstate;
        }

        public double GetLargest()
        {
            RealEstate largestRealEstate= RealEstates.OrderByDescending(x => x.Size).First();
            return largestRealEstate.Size;
        }

        public string EstateReport()
        {
            StringBuilder sbResult= new StringBuilder();
            sbResult.AppendLine("Real estates available:");
            foreach(var realEstate in RealEstates)
            {
                sbResult.AppendLine(realEstate.ToString());
            }

            return sbResult.ToString().Trim();
        }

 
    }
}
