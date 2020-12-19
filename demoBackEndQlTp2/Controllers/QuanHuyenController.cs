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
    public class QuanHuyenController : ControllerBase
    {
        private readonly APIDbContext _context;
        private readonly IMapper _mapper;
        public QuanHuyenController(APIDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // GET: api/QuanHuyen/listId
        [HttpGet("listId")]
        public async Task<ActionResult<List<int>>> GetQuanHuyen()
        {
            return await _context.quanHuyens.Select(x => x.MaQuanHuyen).ToListAsync();

        }

        // GET: api/QuanHuyen/phantrang
        [HttpGet("phantrang")]
        public ActionResult<IEnumerable<QuanHuyen>> GetQuanHuyenPt([FromQuery] thamsoPhanTrang tsPhantrang)
        {

            IQueryable<QuanHuyen> quanHuyens = _context.quanHuyens.Include(x => x.ThanhPho);
            var quanhuyens = pagination<QuanHuyen>.Topagination((IQueryable<QuanHuyen>)quanHuyens, tsPhantrang.currentPage, tsPhantrang.PageSize);
            var metadata = new
            {
                quanhuyens,
                quanhuyens.TotalCount,
                quanhuyens.PageSize,
                quanhuyens.CurrentPage,
                quanhuyens.TotalPages,
                quanhuyens.HasNext,
                quanhuyens.HasPrevious
            };
            return Ok(metadata);
        }

        // GET: api/QuanHuyen
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuanHuyenView>>> GetquanHuyens()
        {
            List<QuanHuyen> quanHuyens = await _context.quanHuyens.Include(x => x.ThanhPho).ToListAsync();
            List<QuanHuyenView> quanHuyenViews = _mapper.Map<List<QuanHuyenView>>(quanHuyens);
            return quanHuyenViews;
        }

        // GET: api/QuanHuyen/GetQuanHuyen/5
        [HttpGet("GetQuanHuyen/{id}")]
        public async Task<ActionResult<List<QuanHuyen>>> GetQuanHuyen(int id)
        {
            List<QuanHuyen> quanHuyens = await _context.quanHuyens.Where(x => x.MaTp == id).ToListAsync();
            return quanHuyens;
        }

      

        // GET: api/QuanHuyen/XaPhuong/5
        [HttpGet("GetXaPhuong/{id}")]
        public async Task<ActionResult>GetXaPhuong(int id)
        {
            var quanHuyens = await _context.quanHuyens.Where(x => x.MaTp == id).Select(x => x.MaQuanHuyen).ToListAsync();
            var result = string.Empty;
            foreach (var item in quanHuyens)
            {
                var XaPhuong = await _context.xaPhuongs.Where(x => x.MaQuanHuyen == item).Select(x => x.TenXaPhuong).ToListAsync();
                if (quanHuyens.Count == 0)
                {
                    result += "<br>";
                }
                foreach (var _item in quanHuyens)
                {
                    result += _item + "<br>";
                }
            }
            if (result == null)
            {
                return NotFound();
            }
            return Ok(new { QuanHuyen = result });
        }

        // PUT: api/QuanHuyen/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuanHuyen(int id, QuanHuyenView quanHuyenView)
        {
            if (id != quanHuyenView.MaQuanHuyen)
            {
                return BadRequest();
            }
            QuanHuyen quanHuyen = _mapper.Map<QuanHuyen>(quanHuyenView);

            _context.Entry(quanHuyen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuanHuyenExists(id))
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

        // POST: api/QuanHuyen
        [HttpPost]
        public async Task<ActionResult<QuanHuyen>> PostQuanHuyen(QuanHuyenView quanHuyenView)
        {
            QuanHuyen quanHuyen = _mapper.Map<QuanHuyen>(quanHuyenView);
            _context.quanHuyens.Add(quanHuyen);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuanHuyen", new { id = quanHuyen.MaQuanHuyen }, quanHuyen);
        }

        // DELETE: api/QuanHuyen/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<QuanHuyen>> DeleteQuanHuyen(int id)
        {
            var quanHuyen = await _context.quanHuyens.FindAsync(id);
            if (quanHuyen == null)
            {
                return NotFound();
            }

            _context.quanHuyens.Remove(quanHuyen);
            await _context.SaveChangesAsync();

            return quanHuyen;
        }

        private bool QuanHuyenExists(int id)
        {
            return _context.quanHuyens.Any(e => e.MaQuanHuyen == id);
        }
    }
}
