using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    [Serializable]
    public class DriverDTO
    {
        [Key]
        public string Id { get; set; }
        public PersonalInfoDTO PersonalInfo { get; set; }
        public List<OVPAthWayDTO> Routes { get; set; }

        public DriverDTO ShallowCopy()
        {
            return (DriverDTO)this.MemberwiseClone();
        }

        public DriverDTO DeepCopy()
        {
            DriverDTO clone = (DriverDTO)this.MemberwiseClone();
            clone.Id = Guid.NewGuid().ToString();
            return clone;
        }

    }
}
