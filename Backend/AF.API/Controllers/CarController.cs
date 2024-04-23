using AF.Application;
using AF.Infrastructure.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AF.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase {

        private Manager _manager;

        public CarController(Manager manager)
        {
            this._manager = manager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _manager.GetAllAsync();
            return Ok(result);
        }

/*        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarById(int id)
        {
            var result = await _carRepository.GetByIdAsync(id);
            return Ok(result);
        }*/
    }
}
