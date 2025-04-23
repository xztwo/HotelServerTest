using Microsoft.AspNetCore.Mvc;
using HotelServer.Models;
using Microsoft.EntityFrameworkCore;
using HotelServer.Data;

namespace HotelServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceRequestController : ControllerBase
    {
        private readonly AppDbContext _db;

        public ServiceRequestController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _db.ServiceRequests.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ServiceRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _db.ServiceRequests.AddAsync(request);
            await _db.SaveChangesAsync();

            return Ok(new { message = "Заявка успешно отправлена.", id = request.Id });
        }
    }
}