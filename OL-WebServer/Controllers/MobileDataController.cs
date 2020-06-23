using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiTeszt2.Models;

namespace WebApiTeszt2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MobileDataController : ControllerBase
    {
        private readonly IoTServerDBContext _context;

        public MobileDataController(IoTServerDBContext context)
        {
            _context = context;
        }

        // GET: api/MobileData
        [HttpGet]
        public IEnumerable<Tuple<int, string, string>> GetStaticData()
        {
            return from a in _context.DataMs select Tuple.Create(a.DataId, a.CoordX, a.CoordY);
        }

        // GET: api/MobileData/5
        [HttpGet("{id}")]
        public IEnumerable<Tuple<int,string,string,string>> GetDataMs(int id)
        {
            return from a in _context.DataMs
                   join b in _context.Sensors on a.SensorId equals b.SensorId
                   where a.DataId==id
                   select Tuple.Create(a.Pm10, a.Date, b.Name, b.Ip);


            /*return from a in _context.DataSs
            join b in _context.Sensors on a.SensorId equals b.SensorId
            select Tuple.Create(a.DataId,b.CoordX,b.CoordY);*/

            /*
            var dataMs = await _context.DataMs.FindAsync(id);

            if (dataMs == null)
            {
                return NotFound();
            }

            return dataMs;*/
        }

        /*
        // PUT: api/MobileData/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDataMs(int id, DataMs dataMs)
        {
            if (id != dataMs.DataId)
            {
                return BadRequest();
            }

            _context.Entry(dataMs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DataMsExists(id))
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

        // POST: api/MobileData
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<DataMs>> PostDataMs(DataMs dataMs)
        {
            _context.DataMs.Add(dataMs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDataMs", new { id = dataMs.DataId }, dataMs);
        }

        // DELETE: api/MobileData/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DataMs>> DeleteDataMs(int id)
        {
            var dataMs = await _context.DataMs.FindAsync(id);
            if (dataMs == null)
            {
                return NotFound();
            }

            _context.DataMs.Remove(dataMs);
            await _context.SaveChangesAsync();

            return dataMs;
        }

        private bool DataMsExists(int id)
        {
            return _context.DataMs.Any(e => e.DataId == id);
        }
        */
    }
}
