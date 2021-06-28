using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Interfaces
{
    public interface IMediator
    {
        void Swap();
        RouteDTO ReturnSwappedDTO();
        void Clear();
        RouteDTO ReturnClearedDTO();
    }
}
