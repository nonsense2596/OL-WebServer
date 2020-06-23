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
    public class StaticDataController : ControllerBase
    {
        private readonly IoTServerDBContext _context;

        public StaticDataController(IoTServerDBContext context)
        {
            _context = context;
        }

        // GET: api/StaticData
        [HttpGet]
        public IEnumerable<Tuple<int, string, string>> GetStaticData()
        {
            /*return from a in _context.Sensors where a.Mode==true select Tuple.Create(a.Name);*/
            /*return from a in _context.DataSs
                   join b in _context.Sensors on a.SensorId equals b.SensorId
                   select Tuple.Create(a.DataId,b.CoordX,b.CoordY);*/
            return from a in _context.Sensors where a.Mode == true select Tuple.Create(a.SensorId, a.CoordX, a.CoordY);
        }


        // GET: api/StaticData/5
        [HttpGet("{id}")]
        public IEnumerable<Tuple<int, string, string, string>> GetDataSs(int id)
        {
            return from a in _context.Sensors
                   join b in _context.DataSs on a.SensorId equals b.SensorId
                   where a.SensorId == id
                   select Tuple.Create(b.Pm10, b.Date, a.Name, a.Ip);

            
            /*var dataSs = await _context.DataSs.FindAsync(id);

            if (dataSs == null)
            {
                return NotFound();
            }

            return dataSs;*/
        }

        /*
        // PUT: api/StaticData/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDataSs(int id, DataSs dataSs)
        {
            if (id != dataSs.DataId)
            {
                return BadRequest();
            }

            _context.Entry(dataSs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DataSsExists(id))
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

        // POST: api/StaticData
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<DataSs>> PostDataSs(DataSs dataSs)
        {
            _context.DataSs.Add(dataSs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDataSs", new { id = dataSs.DataId }, dataSs);
        }

        // DELETE: api/StaticData/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DataSs>> DeleteDataSs(int id)
        {
            var dataSs = await _context.DataSs.FindAsync(id);
            if (dataSs == null)
            {
                return NotFound();
            }

            _context.DataSs.Remove(dataSs);
            await _context.SaveChangesAsync();

            return dataSs;
        }

        private bool DataSsExists(int id)
        {
            return _context.DataSs.Any(e => e.DataId == id);
        }
        */
    }
}
