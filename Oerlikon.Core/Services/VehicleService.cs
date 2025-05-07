using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Oerlikon.Core.Databases;
using Oerlikon.Core.Interfaces;
using Oerlikon.Core.Models.Vehicles;

namespace Oerlikon.Core.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly DatabaseContext _dbContext;

        public VehicleService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<VehicleResponse>> GetVehicles(GetAllVehicleRequest request)
        {
            var data = await _dbContext.Vehicles.AsNoTracking()
                 .Select(x => new VehicleResponse
                 {
                     PlateNo = x.PlateNo,
                     Uid = x.UID
                 }).ToListAsync();
            return data;
        }
    }
}
