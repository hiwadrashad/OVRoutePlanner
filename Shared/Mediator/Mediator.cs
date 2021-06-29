using Shared.Entities;
using Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.ExtensionMethods;

namespace Shared.Mediator
{
    public class Mediator : IMediator
    {
        private RouteDTO _emptyRoute;

        private RouteDTO _filledInRoute;

        public Mediator(RouteDTO emptyRoute, RouteDTO filledInRoute)
        {
            this._emptyRoute = emptyRoute;
            this._filledInRoute = filledInRoute;
        }

        public void Clear()
        {
            this._emptyRoute = new RouteDTO();
        }

        public RouteDTO ReturnClearedDTO()
        {
            this._emptyRoute = new RouteDTO();
            return this._emptyRoute;
        }

        public void Swap()
        {
            if (this._filledInRoute.IsSerializable())
            {
                this._emptyRoute = _filledInRoute.DeepClone();
            }
            else
            {
                this._emptyRoute = _filledInRoute.ShallowCopy();
            }
        }

        public RouteDTO ReturnSwappedDTO()
        {
            if (this._filledInRoute.IsSerializable())
            {
                this._emptyRoute = _filledInRoute.DeepClone();
            }
            else
            {
                this._emptyRoute = _filledInRoute.ShallowCopy();
            }

            return this._emptyRoute;
        }
    }
}
