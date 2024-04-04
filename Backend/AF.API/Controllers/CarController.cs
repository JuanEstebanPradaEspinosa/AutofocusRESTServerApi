using AF.DL.Entities;
using AF.DL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : Controller
    {
        private readonly CarRepository _carRepo;
        public CarController(CarRepository carRepo)
        {
            _carRepo = carRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetAllAutos()
        {
            var autos = await _carRepo.GetAll();
            return Ok(autos);
        }
    }
}
