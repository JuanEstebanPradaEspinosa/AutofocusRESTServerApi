using AF.Domain.Entities;
using AF.Infrastructure.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AF.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase {
        private readonly IRepository<Car> _carRepository;
        public CarController(IRepository<Car> carRepository) {
            _carRepository = carRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync() {
            var result = await _carRepository.GetAllAsync(); 
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarById(int id) {
            var result = await _carRepository.GetByIdAsync(id);
            return Ok(result);
        }
    }
}
