using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class JournalistsController : BaseApiController
    {
        private readonly DataContext _context;
        public JournalistsController(DataContext context)
        {
            _context = context;
        }


        [HttpGet] // GET: api/journalists
        public async Task<ActionResult<IEnumerable<Journalist>>> GetJournalists()
        {
            return await _context.Journalists.ToListAsync();
        }

        [HttpGet("{id}")] // GET: api/journalists/{id}
        public async Task<ActionResult<Journalist>> GetJournalist(int id)
        {
            return await _context.Journalists.FindAsync(id);
        }
    }
}