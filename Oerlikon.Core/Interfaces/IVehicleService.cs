using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oerlikon.Core.Databases;
using Oerlikon.Core.Models.Vehicles;

namespace Oerlikon.Core.Interfaces
{
    public interface IVehicleService
    {
        Task<List<VehicleResponse>> GetVehicles(GetAllVehicleRequest request);

        Task SubmitVehicle(SubmitVehicleRequest request);

        Task<VehicleDetailResponse> GetDetail(Guid uid);


    }
}
