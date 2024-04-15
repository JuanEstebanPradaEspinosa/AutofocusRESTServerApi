using AF.Domain.Entities;
using AF.Infrastructure.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AF.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase {
        private readonly IRepository<Booking> _bookingRepository;
        public BookingController(IRepository<Booking> bookingRepository) {
            _bookingRepository = bookingRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync() {
            var result = await _bookingRepository.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookingById(int id) {
            var result = await _bookingRepository.GetByIdAsync(id);
            if (result == null) {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
