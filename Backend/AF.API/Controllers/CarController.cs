
using AF.Application;
using AF.Application.DTO_s.Input;
using AF.Application.DTO_s.Output;
using AF.Application.Models;
using AF.Domain.Pagination;
using AF.Infrastructure.QueryParameters;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AF.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
#if ProducesConsumes
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
#endif
    public class CarController : ControllerBase {

        private Manager _manager;
        private IMapper _mapper;

        public CarController(Manager manager, IMapper mapper)
        {
            this._manager = manager;
            this._mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResult<PagedList<CarRESToutputDTO>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PagedList<CarRESToutputDTO>>> GetAllCarsAsync([FromQuery] CarParameters carParameters)
        {
            try
            {
                PagedList<CarRESToutputDTO> Cars = new();
                var results = await _manager.GetAllCarsAsync(carParameters);

                var metadata = new
                {
                    results.TotalCount,
                    results.PageSize,
                    results.CurrentPage,
                    results.TotalPages,
                    results.HasNext,
                    results.HasPrevious
                };

                results.ForEach(car =>
                {
                    Cars.Add(_mapper.Map<CarRESToutputDTO>(car));
                });

                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

                return Ok(Cars);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
                throw;
            }
        }

        [HttpGet("{carId}")]
        public async Task<ActionResult<CarRESToutputDTO>> GetCarByIdAsync(int carId)
        {
            try
            {
                var car = await _manager.GetCarByIdAsync(carId);

                if (car == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<CarRESToutputDTO>(car));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        [HttpPost("{lessorId}")]
        public async Task<ActionResult<CarRESTinputDTO>> AddCarAsync(int lessorId, [FromBody] CarRESTinputDTO carRESTinputDTO)
        {
            try
            {
                CarModel car = _mapper.Map<CarModel>(carRESTinputDTO);
                await _manager.AddCarAsync(lessorId , car);

                //this still have to change so that you gave a completed DTO to show of!
                return Ok(carRESTinputDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        // PUT: api/car/{id}
        [HttpPut("{carId}")]
        public async Task<ActionResult<CarRESToutputDTO>> UpdateCarAsync(int carId, [FromBody] CarRESTinputDTO carRESTinputDTO)
        {
            try
            {
                //Use OnCreated methodes to use the id and show outputDTO - methodes have the id to control if the entity exist! 
                //TODO:
                CarModel car = _mapper.Map<CarModel>(carRESTinputDTO);
                //Ideaal zal deze methode de geupdated object terug geven om aan de ui te geven met zijn id!
                //voorlopig wordt de timing lijst opnieuw opgevraagd telkens!
                await _manager.UpdateCarAsync(carId,car);

                return Ok(carRESTinputDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        // DELETE: api/Timing/{id}
        [HttpDelete("{carId}")]
        public async Task<ActionResult> RemoveCarAsync(int carId)
        {
            try
            {
                await _manager.RemoveCarAsync(carId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }

        }

    }


}
