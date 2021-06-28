using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class OVPAthWayDTO
    {
        [Key]
        public string id { get; set; }
        public List<Dictionary<string, int>> LocationWaitTimes { get; set; }

    }
}
