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
        public string Id { get; set; }
        public List<Dictionary<string, int>> LocationWaitTimes { get; set; }

        public OVPAthWayDTO ShallowCopy()
        {
            return (OVPAthWayDTO)this.MemberwiseClone();
        }

        public OVPAthWayDTO DeepCopy()
        {
            OVPAthWayDTO clone = (OVPAthWayDTO)this.MemberwiseClone();
            clone.Id = Guid.NewGuid().ToString();
            return clone;
        }

    }
}
