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
    public class OStocksController : Controller
    {
        private readonly ContextApi _context;

        public OStocksController(ContextApi context)
        {
            _context = context;
        }

        // GET: OStocks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OStock>>> GetOStock()
        {
            return await _context.OStock.ToListAsync();
        }
        // GET: OStocks/Details/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OStock>> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stock = await _context.OStock
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stock == null)
            {
                return NotFound();
            }

            return stock;
        }
        // POST: OStocks/Create
        [HttpPost]
        public async Task<ActionResult<OStock>> CreateStock(OStock stock)
        {
            _context.OStock.Add(stock);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Details), new { id = stock.Id }, stock);
        }
        [HttpGet]
        private bool StockExists(int id)
        {
            return _context.OStock.Any(e => e.Id == id);
        }

        // POST: OStocks/Edit/5
        [HttpPost("{id}")]
        public async Task<IActionResult> Edit(int id, OStock stock)
        {
            if (id != stock.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(stock);
                await _context.SaveChangesAsync();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var stock = _context.OStock.FirstOrDefault(e => e.Id == id);
            if (stock == null)
            {
                return NotFound();
            }
            _context.OStock.Remove(stock);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
