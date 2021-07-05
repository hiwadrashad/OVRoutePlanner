using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    [Serializable]
    public class RouteDTO
    {
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public DateTime StartingTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime Date { get; set; }
        public TransportPathway Directions { get; set; } = new TransportPathway();
        public RouteDTO ShallowCopy()
        {
            return (RouteDTO)this.MemberwiseClone();
        }
    }
}
