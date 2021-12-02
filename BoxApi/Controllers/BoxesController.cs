using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BoxApi.Models;

namespace BoxApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoxesController : Controller
    {
        private readonly ContextApi _context;

        public BoxesController(ContextApi context)
        {
            _context = context;
        }

        // GET: Boxes

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Box>>> GetBoxs()
        {
            return await _context.Boxs.ToListAsync();
        }
        // GET: Boxes/Details/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Box>> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var box = await _context.Boxs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (box == null)
            {
                return NotFound();
            }

            return box;
        }
        // POST: Boxes/Create
        [HttpPost]
        public async Task<ActionResult<Box>> CreateBox(Box box)
        {
                _context.Boxs.Add(box);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(Details),new {id=box.Id},box);
        }
        [HttpGet]
        private bool BoxExists(int id)
        {
            return _context.Boxs.Any(e => e.Id == id);
        }

        // POST: Boxes/Edit/5
        [HttpPost("{id}")]
        public async Task<IActionResult> Edit(int id, Box box)
        {
            if (id != box.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                    _context.Update(box);
                    await _context.SaveChangesAsync();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var box = _context.Boxs.FirstOrDefault(e => e.Id == id);
            if (box == null)
            {
                return NotFound();
            }
            _context.Boxs.Remove(box);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
