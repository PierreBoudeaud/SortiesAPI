using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BO;
using DAL;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SortiesAPI.Models;
using Weather = BO.Weather;

namespace SortiesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcursionsController : ControllerBase
    {
        private readonly Context _context;
        private readonly WeatherAPIConfig _weatherApiConfig;

        public ExcursionsController(Context context, IOptions<WeatherAPIConfig> weatherConfig)
        {
            _context = context;
            _weatherApiConfig = weatherConfig.Value;
        }

        // GET: api/Excursions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Excursion>>> GetExcursions()
        {
            return await _context.Excursions.OrderByDescending(e => e.Date).ToListAsync();
        }

        // GET: api/Excursions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Excursion>> GetExcursion(Guid id)
        {
            var excursion = await _context.Excursions
                .Include(e => e.SubscribePeople)
                .Include(e => e.Activity)
                .Include(e => e.Creator)
                .Include(e => e.Creator.SubExcursions)
                .Include(e => e.Weather)
                .FirstAsync(e => e.Id == id);

            if (excursion == null)
            {
                return NotFound();
            }
            
            return prepareExcursion(excursion);
        }

        // PUT: api/Excursions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExcursion(Guid id, Excursion excursion)
        {
            if (id != excursion.Id)
            {
                return BadRequest();
            }
            
            if ( excursion.Weather == null
                    || (excursion.Weather != null && (
                            excursion.Activity.Latitude != excursion.Weather.Latitude 
                            || excursion.Activity.Longitude != excursion.Weather.Longitude)
                        ))
            {
                await getWeatherAsync(excursion);
                _context.Entry(excursion.Weather).State = EntityState.Added;
            }
            _context.Entry(excursion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExcursionExists(id))
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

        // POST: api/Excursions
        [HttpPost]
        public async Task<ActionResult<Excursion>> PostExcursion(Excursion excursion)
        {
            excursion.Activity = await _context.Activities.FindAsync(excursion.Activity.Id);
            excursion.Creator = await _context.People.FindAsync(excursion.Creator.Id);
            await getWeatherAsync(excursion);
            _context.Excursions.Add(excursion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExcursion", new { id = excursion.Id }, prepareExcursion(excursion));
        }

        // DELETE: api/Excursions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Excursion>> DeleteExcursion(Guid id)
        {
            var excursion = await _context.Excursions.FindAsync(id);
            if (excursion == null)
            {
                return NotFound();
            }

            _context.Excursions.Remove(excursion);
            await _context.SaveChangesAsync();

            return prepareExcursion(excursion);
        }

        private bool ExcursionExists(Guid id)
        {
            return _context.Excursions.Any(e => e.Id == id);
        }

        private Excursion prepareExcursion(Excursion excurison)
        {
            foreach (var personsExcursions in excurison.SubscribePeople)
            {
                _context.Entry(personsExcursions).Reference(pe => pe.Person).Load();
                personsExcursions.Person.SubExcursions.Clear();
            }

            excurison.Creator.SubExcursions.Clear();
            excurison.Activity.Excursions.Clear();

            return excurison;
        }

        private async Task getWeatherAsync(Excursion excursion)
        {
            if (excursion.Weather != null)
            {
                excursion.Weather = null;
            }
            var client = new WebClient();
            client.QueryString.Add("APPID", _weatherApiConfig.APIKey);
            client.QueryString.Add("units", _weatherApiConfig.Units);
            client.QueryString.Add("lang", _weatherApiConfig.Lang);
            client.QueryString.Add("lat", excursion.Activity.Latitude.ToString());
            client.QueryString.Add("lon", excursion.Activity.Longitude.ToString());
            var result = client.DownloadStringTaskAsync(@"http://api.openweathermap.org/data/2.5/weather");
            var weatherJson =  JsonConvert.DeserializeObject<WeatherJson>(await result);
            excursion.Weather = weatherJson.ConvertToWeatherBO();
        }
    }
}
