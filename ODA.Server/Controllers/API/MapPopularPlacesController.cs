using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ODA.Server.Context;
using ODA.Server.Entity;

namespace ODA.Server.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapPopularPlacesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MapPopularPlacesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/MapPopularPlaces
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MapPopularPlace>>> GetMapPopularPlaces()
        {
            return await _context.MapPopularPlaces.ToListAsync();
        }

        // GET: api/MapPopularPlaces/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MapPopularPlace>> GetMapPopularPlace(string id)
        {
            var mapPopularPlace = await _context.MapPopularPlaces.FindAsync(id);

            if (mapPopularPlace == null)
            {
                return NotFound();
            }

            return mapPopularPlace;
        }

        // PUT: api/MapPopularPlaces/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMapPopularPlace(string id, MapPopularPlace mapPopularPlace)
        {
            if (id != mapPopularPlace.Place)
            {
                return BadRequest();
            }

            _context.Entry(mapPopularPlace).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MapPopularPlaceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/MapPopularPlaces
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MapPopularPlace>> PostMapPopularPlace([FromForm]MapPopularPlace mapPopularPlace)
        {
            _context.MapPopularPlaces.Add(mapPopularPlace);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MapPopularPlaceExists(mapPopularPlace.Place))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMapPopularPlace", new { id = mapPopularPlace.Place }, mapPopularPlace);
        }

        // DELETE: api/MapPopularPlaces/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MapPopularPlace>> DeleteMapPopularPlace(string id)
        {
            var mapPopularPlace = await _context.MapPopularPlaces.FindAsync(id);
            if (mapPopularPlace == null)
            {
                return NotFound();
            }

            _context.MapPopularPlaces.Remove(mapPopularPlace);
            await _context.SaveChangesAsync();

            return mapPopularPlace;
        }

        private bool MapPopularPlaceExists(string id)
        {
            return _context.MapPopularPlaces.Any(e => e.Place == id);
        }
    }
}
