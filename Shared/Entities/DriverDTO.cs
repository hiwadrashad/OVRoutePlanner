using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Entities
{
    public class DriverDTO
    {
        [Key]
        public string Id { get; set; }
        public PersonalInfoDTO PersonalInfo { get; set; }
        public List<OVPAthWayDTO> Routes { get; set; } 

    }
}
