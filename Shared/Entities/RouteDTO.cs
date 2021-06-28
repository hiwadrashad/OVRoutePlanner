using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class RouteDTO
    {
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public List<Dictionary<string, int>> LocationWaitTimes { get; set; }
    }
}
