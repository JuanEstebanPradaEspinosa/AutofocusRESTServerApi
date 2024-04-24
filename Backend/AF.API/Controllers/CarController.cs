
using AF.Application;
using AF.Application.DTO_s.Input;
using AF.Application.DTO_s.Output;
using AF.Application.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AF.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase {

        private Manager _manager;
        private IMapper _mapper;

        public CarController(Manager manager, IMapper mapper)
        {
            this._manager = manager;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<CarRESToutputDTO>>> GetAllCarsAsync()
        {
            try
            {
                List<CarRESToutputDTO> Cars = new();
                var results = await _manager.GetAllCarsAsync();

                results.ForEach(car =>
                {
                    Cars.Add(_mapper.Map<CarRESToutputDTO>(car));
                });

                return Ok(Cars);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult<CarRESTinputDTO>> AddCarAsync([FromBody] CarRESTinputDTO carRESTinputDTO)
        {
            try
            {
                CarModel car = _mapper.Map<CarModel>(carRESTinputDTO);
                await _manager.AddCarAsync(car);

                //this still have to change so that you gave a completed DTO to show of!
                return Ok(carRESTinputDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        /*        [HttpGet("{id}")]
                public async Task<IActionResult> GetCarById(int id)
                {
                    var result = await _carRepository.GetByIdAsync(id);
                    return Ok(result);
                }*/
    }


}
