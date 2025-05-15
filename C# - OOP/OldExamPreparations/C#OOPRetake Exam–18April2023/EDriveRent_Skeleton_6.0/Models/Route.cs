using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDriveRent.Models
{
    public class Route : IRoute
    {
        public Route(string startPoint, string endPoint, double length, int routeId)
        {
            if (string.IsNullOrWhiteSpace(startPoint))
                throw new ArgumentException(ExceptionMessages.StartPointNull);

            if (string.IsNullOrWhiteSpace(endPoint))
                throw new ArgumentException(ExceptionMessages.EndPointNull);

            if (length<1)
                throw new ArgumentException(ExceptionMessages.RouteLengthLessThanOne);


            StartPoint = startPoint;
            EndPoint = endPoint;
            Length = length;
            RouteId = routeId;
            IsLocked = false;
        }

        public string StartPoint { get; }
        public string EndPoint { get; }
        public double Length { get; }
        public int RouteId { get; }
        public bool IsLocked { get; private set; }

        public void LockRoute() => this.IsLocked = true;
    }
}
