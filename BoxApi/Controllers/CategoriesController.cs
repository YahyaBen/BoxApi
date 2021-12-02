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
    public class CategoriesController : Controller
    {
        private readonly ContextApi _context;

        public CategoriesController(ContextApi context)
        {
            _context = context;
        }

        // GET: Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categorie>>> GetCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        // GET: Categories/Details/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Categorie>> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorie = await _context.Categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categorie == null)
            {
                return NotFound();
            }

            return categorie;
        }

        // GET: Categories/Create
        [HttpPost]
        public async Task<ActionResult<Categorie>> CreateCategorie(Categorie categorie)
        {
            _context.Categories.Add(categorie);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Details), new { id = categorie.Id }, categorie);
        }
        [HttpGet]
        private bool CategorieExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }

        // POST: Categories/Edit/5
        [HttpPost("{id}")]
        public async Task<IActionResult> Edit(int id, Categorie categorie)
        {
            if (id != categorie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(categorie);
                await _context.SaveChangesAsync();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var categorie = _context.Categories.FirstOrDefault(e => e.Id == id);
            if (categorie == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(categorie);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
