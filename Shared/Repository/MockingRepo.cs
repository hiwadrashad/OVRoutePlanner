using Shared.Entities;
using Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Repository
{
    public class MockingRepo : IMockingRepo
    {
        private List<DriverDTO> _drivers;

        private List<OVPAthWayDTO> _buspathway;

        private static MockingRepo mockingRepo;

        private MockingRepo()
        { 
        
        }

        public static MockingRepo GetMockingRepo()
        {
            if (mockingRepo == null)
            {
                mockingRepo = new MockingRepo();
                mockingRepo.InitData();
            }

            return mockingRepo;
        }

        public OVPAthWayDTO GeneralizedPathway = new OVPAthWayDTO()
        {
            Id = Guid.NewGuid().ToString(),
            LocationWaitTimes = new List<Dictionary<string, int>>()
            {
                new Dictionary<string, int>()
                {
                    { "Ijsselsteinlaan",30},
                    { "Utrecht Centraal",4},
                    { "Klopvaart",7 },
                    { "Vechtsebanen", 4}

                }
            }
        };

        private void InitData()
        {
            _drivers = new List<DriverDTO>
            {
                new DriverDTO()
                { 
                  Id = Guid.NewGuid().ToString(),
                  PersonalInfo = new PersonalInfoDTO()
                  { 
                    Email = "jamesjohnson@gmail.com",
                    Name = "James Johnson",
                    Password = "P@ssw0rd"
                  },
                  Routes = new List<OVPAthWayDTO>()
                  { 
                     GeneralizedPathway
                  }
                }
            };

            _buspathway = new List<OVPAthWayDTO>
            {
              GeneralizedPathway
            };
        }

    }
}
