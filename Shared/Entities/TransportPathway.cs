using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class TransportPathway
    {
        public List<TransportNode> Path { get; set; } = new List<TransportNode>();
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public string StartLatitude { get; set; }
        public string StartLongitude { get; set; }
        public string EndLatitude { get; set; }
        public string EndLongitude { get; set; }
        public bool ErrorFound { get; set; }
    }
}
