using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VS2019TestCore.Model;

[assembly: ApiConventionType(typeof(DefaultApiConventions))]
namespace VS2019TestCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeoLocationsController : ControllerBase
    {
        private readonly GeoLocationContext _context;

        public GeoLocationsController(GeoLocationContext context)
        {
            _context = context;
        }

        // GET: api/GeoLocations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GeoLocations>>> GetGeoLocation()
        {
            return await _context.GeoLocation.ToListAsync();
        }

        // GET: api/GeoLocations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GeoLocations>> GetGeoLocations(int id)
        {
            var geoLocations = await _context.GeoLocation.FindAsync(id);

            if (geoLocations == null)
            {
                return NotFound();
            }

            return geoLocations;
        }

        // PUT: api/GeoLocations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGeoLocations(int id, GeoLocations geoLocations)
        {
            if (id != geoLocations.Id)
            {
                return BadRequest();
            }

            _context.Entry(geoLocations).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeoLocationsExists(id))
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

        // POST: api/GeoLocations
        [HttpPost]
        public async Task<ActionResult<GeoLocations>> PostGeoLocations(GeoLocations geoLocations)
        {
            _context.GeoLocation.Add(geoLocations);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGeoLocations", new { id = geoLocations.Id }, geoLocations);
        }

        // DELETE: api/GeoLocations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GeoLocations>> DeleteGeoLocations(int id)
        {
            var geoLocations = await _context.GeoLocation.FindAsync(id);
            if (geoLocations == null)
            {
                return NotFound();
            }

            _context.GeoLocation.Remove(geoLocations);
            await _context.SaveChangesAsync();

            return geoLocations;
        }

        private bool GeoLocationsExists(int id)
        {
            return _context.GeoLocation.Any(e => e.Id == id);
        }
    }
}
