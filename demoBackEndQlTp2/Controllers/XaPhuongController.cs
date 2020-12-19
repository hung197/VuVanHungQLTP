using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using demoBackEndQlTp2.Models;
using AutoMapper;
using demoBackEndQlTp2.ViewModels;
using demoBackEndQlTp2.Service;

namespace demoBackEndQlTp2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class XaPhuongController : ControllerBase
    {
        private readonly APIDbContext _context;
        private readonly IMapper _mapper;
        public XaPhuongController(APIDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/XaPhuong
        [HttpGet]
        public async Task<ActionResult<IEnumerable<XaPhuongView>>> GetxaPhuongs()
        {
            List<XaPhuong> xaphuongs= await _context.xaPhuongs.Include(x => x.QuanHuyen).ToListAsync();
            List<XaPhuongView> xaPhuongViews = _mapper.Map<List<XaPhuongView>>(xaphuongs);
            return xaPhuongViews;
        }

        // GET: api/XaPhuong/phantrang
        [HttpGet("phantrang")]
        public ActionResult<IEnumerable<XaPhuong>> GetXaPhuongPt([FromQuery] thamsoPhanTrang tsPhantrang)
        {

            IQueryable<XaPhuong> xaPhuongs = _context.xaPhuongs.Include(x => x.QuanHuyen);
            var xaphuongs = pagination<XaPhuong>.Topagination((IQueryable<XaPhuong>)xaPhuongs, tsPhantrang.currentPage, tsPhantrang.PageSize);
            var metadata = new
            {
                xaphuongs,
                xaphuongs.TotalCount,
                xaphuongs.PageSize,
                xaphuongs.CurrentPage,
                xaphuongs.TotalPages,
                xaphuongs.HasNext,
                xaphuongs.HasPrevious
            };
            return Ok(metadata);
        }
        // GET: api/XaPhuong/5
        [HttpGet("{id}")]
        public async Task<ActionResult<XaPhuong>> GetXaPhuong(int id)
        {
            var xaPhuong = await _context.xaPhuongs.FindAsync(id);

            if (xaPhuong == null)
            {
                return NotFound();
            }

            return xaPhuong;
        }

        [HttpGet("GetXaPhuong/{id}")]
        public async Task<ActionResult<List<XaPhuong>>> getQuanHuyen(int id)
        {
             
            List<XaPhuong> xaPhuongs = await _context.xaPhuongs.Where(x => x.MaQuanHuyen == id).ToListAsync();
            return xaPhuongs;
        }

        // PUT: api/XaPhuong/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutXaPhuong(int id, XaPhuongView xaPhuongView)
        {
            if (id != xaPhuongView.MaXaPhuong)
            {
                return BadRequest();
            }
            XaPhuong xaPhuong = _mapper.Map<XaPhuong>(xaPhuongView);
            _context.Entry(xaPhuong).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!XaPhuongExists(id))
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

        // POST: api/XaPhuong
        [HttpPost]
        public async Task<ActionResult<XaPhuong>> PostXaPhuong(XaPhuongView xaPhuongView)
        {
            XaPhuong xaPhuong = _mapper.Map<XaPhuong>(xaPhuongView);
            _context.xaPhuongs.Add(xaPhuong);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetXaPhuong", new { id = xaPhuong.MaXaPhuong }, xaPhuong);
        }

        // DELETE: api/XaPhuong/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<XaPhuong>> DeleteXaPhuong(int id)
        {
            var xaPhuong = await _context.xaPhuongs.FindAsync(id);
            if (xaPhuong == null)
            {
                return NotFound();
            }

            _context.xaPhuongs.Remove(xaPhuong);
            await _context.SaveChangesAsync();

            return xaPhuong;
        }

        private bool XaPhuongExists(int id)
        {
            return _context.xaPhuongs.Any(e => e.MaXaPhuong == id);
        }
    }
}
