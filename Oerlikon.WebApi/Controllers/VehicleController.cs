using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Oerlikon.WebApi.Controllers
{
    [Route("api/vehicles")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly Core.Interfaces.IVehicleService _vehicleService;
        public VehicleController(Core.Interfaces.IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        /// <summary>
        /// get all vehicle
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _vehicleService.GetVehicles(new Core.Models.Vehicles.GetAllVehicleRequest());
            return Ok(response);
        }
    }
}
