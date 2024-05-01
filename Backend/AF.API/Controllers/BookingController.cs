using AF.Application;
using AF.Application.DTO_s;
using AF.Application.Models;
using AF.Infrastructure.Repos;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AF.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase {

        private Manager _manager;
        private IMapper _mapper;

        public BookingController(Manager manager, IMapper mapper)
        {
            this._manager = manager;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<BookingRESTnormalDTO>> GetBookingByIdAsync(int carId, int tenantId)
        {
            try
            {
                var book = await _manager.GetBookingByIdAsync(carId,tenantId);

                if (book == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<BookingRESTnormalDTO>(book));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult<BookingRESTnormalDTO>> AddBookingAsync([FromBody] BookingRESTnormalDTO bookingRESTnormalDTO)
        {
            try
            {
                var book = _mapper.Map<BookingModel>(bookingRESTnormalDTO);
                await _manager.AddBookingAsync(book);

                //this still have to change so that you gave a completed DTO to show of!
                return Ok(bookingRESTnormalDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        // PUT: api/car/{id}
        [HttpPut]
        public async Task<ActionResult<BookingRESTnormalDTO>> UpdateBookingAsync(int carId, int tenantId, [FromBody] BookingRESTnormalDTO bookingRESTnormalDTO)
        {
            try
            {
                //Use OnCreated methodes to use the id and show outputDTO - methodes have the id to control if the entity exist! 
                //TODO:
                var booking = _mapper.Map<BookingModel>(bookingRESTnormalDTO);
                //Ideaal zal deze methode de geupdated object terug geven om aan de ui te geven met zijn id!
                //voorlopig wordt de timing lijst opnieuw opgevraagd telkens!
                await _manager.UpdateBookingAsync(carId,tenantId,booking);

                return Ok(booking);//CreatedAtAction(nameof(GetCarByIdAsync), new { carId = car.Id }, carRESTinputDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        // DELETE: api/Timing/{id}
        [HttpDelete]
        public async Task<ActionResult> RemoveBookingAsync(int carId, int tenantId)
        {
            try
            {
                await _manager.RemoveBookingAsync(carId,tenantId);
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
