using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oerlikon.Core.Models.Vehicles
{
    public class GetAllVehicleRequest
    {
        
    }

    public class VehicleResponse
    {
        public Guid Uid { get; set; }

        public string PlateNo { get; set; }
    }
}
