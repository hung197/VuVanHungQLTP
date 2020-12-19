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
using Newtonsoft.Json;

namespace demoBackEndQlTp2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThanhPhoController : ControllerBase
    {
        private readonly APIDbContext _context;
        private readonly IMapper _mapper;

        public ThanhPhoController(APIDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/ThanhPho
        [HttpGet]
        public ActionResult<pagination<ThanhPho>> GetthanhPhos([FromQuery] thamsoPhanTrang tsPhantrang)
        {

            IQueryable<ThanhPho> thanhPhos = _context.thanhPhos;
            //List<ThanhPhoView> thanhPhoViews = _mapper.Map<List<ThanhPhoView>>(thanhPhos);

            var thanhphos = pagination<ThanhPho>.Topagination(thanhPhos, tsPhantrang.currentPage, tsPhantrang.PageSize);
            var metadata = new
            {
                thanhphos,  
                thanhphos.TotalCount,
                thanhphos.PageSize,
                thanhphos.CurrentPage,
                thanhphos.TotalPages,
                thanhphos.HasNext,
                thanhphos.HasPrevious
            };

            return Ok(metadata);
        }

        // GET: api/ThanhPho
        [HttpGet("getAll")]
        public async Task<ActionResult<IEnumerable<ThanhPho>>> GetthanhPhos()
        {
            return await _context.thanhPhos.ToListAsync();
        }
        // GET: api/ThanhPho/listId
        [HttpGet("listId")]
        public async Task<ActionResult<List<int>>> GetMaTp()
        {
            return await _context.thanhPhos.Select(x => x.MaTp).ToListAsync();
        }

        // GET: api/ThanhPho/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ThanhPho>> GetThanhPho(int id)
        {
            var thanhPho = await _context.thanhPhos.FindAsync(id);

            if (thanhPho == null)
            {
                return NotFound();
            }

            return thanhPho;
        }

        // PUT: api/ThanhPho/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutThanhPho(int id, ThanhPhoView thanhPhoView)
        {

            if (id != thanhPhoView.MaTp)

            {
                return BadRequest();
            }
            ThanhPho thanhPho = _mapper.Map<ThanhPho>(thanhPhoView);
            _context.Entry(thanhPho).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThanhPhoExists(id))
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

        // POST: api/ThanhPho
        [HttpPost]
        public async Task<ActionResult<ThanhPho>> PostThanhPho(ThanhPhoView thanhPhoView)
        {
            ThanhPho thanhPho = _mapper.Map<ThanhPho>(thanhPhoView);
            _context.thanhPhos.Add(thanhPho);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetThanhPho", new { id = thanhPho.MaTp }, thanhPho);
        }

        // DELETE: api/ThanhPho/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ThanhPho>> DeleteThanhPho(int id)
        {
            var thanhPho = await _context.thanhPhos.FindAsync(id);
            if (thanhPho == null)
            {
                return NotFound();
            }

            _context.thanhPhos.Remove(thanhPho);
            await _context.SaveChangesAsync();

            return thanhPho;
        }

        private bool ThanhPhoExists(int id)
        {
            return _context.thanhPhos.Any(e => e.MaTp == id);
        }
    }
}
