using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Oerlikon.Core.Commons;
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
                     Uid = x.UID,
                     Brand = x.Brand
                 }).ToListAsync();
            return data;
        }

        public async Task SubmitVehicle(SubmitVehicleRequest request)
        {
            if (request.Uid == null)
            {
                await AddVehicle(request);
            }
            else
            {
                await UpdateVehicle(request); 
            }
        }
        private async Task AddVehicle(SubmitVehicleRequest request)
        {
            var now = DateTimeHelper.GetCurrentTime();
            await _dbContext.Vehicles.AddAsync(new Vehicle
            {
                 Color = request.Color,
                 Brand = request.Brand,
                 PlateNo = request.PlateNo,
                 CreatedAt = now
                 
            });
            await _dbContext.SaveChangesAsync();
        }
        private async Task UpdateVehicle(SubmitVehicleRequest request)
        {
            var existingData = await _dbContext.Vehicles
                .FirstOrDefaultAsync(x=>x.UID == request.Uid);
            if (existingData == null)
                return;
            existingData.PlateNo = request.PlateNo;
            existingData.Color = request.Color;
            existingData.Brand = request.Brand;
            await _dbContext.SaveChangesAsync();
        }


        public async Task<VehicleDetailResponse> GetDetail(Guid uid)
        {
            var existingData = await _dbContext.Vehicles
               .FirstOrDefaultAsync(x => x.UID == uid);
            if (existingData == null)
                throw new Core.Exceptions.BadRequestException("vehicle is not found");
            return new VehicleDetailResponse
            {
                 Brand = existingData.Brand,
                 Color = existingData.Color,
                 PlateNo = existingData.PlateNo,
                 Uid= existingData.UID
            };
        }

        public async Task DeleteVehicle(Guid id)
        {
            var existingData = await _dbContext.Vehicles.FirstOrDefaultAsync(x => x.UID == id);
            if (existingData != null)
            {
                _dbContext.Vehicles.Remove(existingData);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
