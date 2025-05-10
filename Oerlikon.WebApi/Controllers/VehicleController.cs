using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oerlikon.Core.Exceptions;
using Oerlikon.Core.Models.Vehicles;

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

        /// <summary>
        /// get all vehicle
        /// </summary>
        /// <returns></returns>
        [HttpGet("{uid}")]
        public async Task<IActionResult> GetDetail([FromRoute]Guid uid)
        {
            try
            {
                var response = await _vehicleService.GetDetail(uid);
                return Ok(response);
            }
            catch (BadRequestException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An unexpected error occurred. {ex.Message}");
            }
        }


        /// <summary>
        /// get all vehicle
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Submit([FromBody] SubmitVehicleRequest request)
        {
            try
            {
                await _vehicleService.SubmitVehicle(request);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
