//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using WebApiTeszt2.Models;

//namespace WebApiTeszt2.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class DataMsController : ControllerBase
//    {
//        private readonly IoTServerDBContext _context;

//        public DataMsController(IoTServerDBContext context)
//        {
//            _context = context;
//        }

//        // GET: api/DataMs
//        [HttpGet("kek")]
//        //[HttpGet]
//        public async Task<ActionResult<IEnumerable<DataMs>>> GetDataMs()
//        //public IQueryable<Object> GetDataMs()
//        {
//            return await _context.DataMs.ToListAsync();
//           // return from a in _context.DataMs
//           //        join b in _context.Sensors on a.SensorId equals b.SensorId
//           //        select b.Ip;
//        }


//        // GET: api/DataMs/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<DataMs>> GetDataMs(int id)
//        {
//            var dataMs = await _context.DataMs.FindAsync(id);

//            if (dataMs == null)
//            {
//                return NotFound();
//            }

//            return dataMs;
//        }

//        // PUT: api/DataMs/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
//        // more details see https://aka.ms/RazorPagesCRUD.
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutDataMs(int id, DataMs dataMs)
//        {
//            if (id != dataMs.DataId)
//            {
//                return BadRequest();
//            }

//            _context.Entry(dataMs).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!DataMsExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }

//        // POST: api/DataMs
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
//        // more details see https://aka.ms/RazorPagesCRUD.
//        [HttpPost]
//        public async Task<ActionResult<DataMs>> PostDataMs(DataMs dataMs)
//        {
//            _context.DataMs.Add(dataMs);
//            await _context.SaveChangesAsync();

//            //return CreatedAtAction("GetDataMs", new { id = dataMs.DataId }, dataMs);
//            return CreatedAtAction(nameof(GetDataMs), new { id = dataMs.DataId }, dataMs);
//        }


//        // DELETE: api/DataMs/5
//        [HttpDelete("{id}")]
//        public async Task<ActionResult<DataMs>> DeleteDataMs(int id)
//        {
//            var dataMs = await _context.DataMs.FindAsync(id);
//            if (dataMs == null)
//            {
//                return NotFound();
//            }

//            _context.DataMs.Remove(dataMs);
//            await _context.SaveChangesAsync();

//            return dataMs;
//        }

//        private bool DataMsExists(int id)
//        {
//            return _context.DataMs.Any(e => e.DataId == id);
//        }
//    }
//}
