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
    public class CommandesController : Controller
    {
        private readonly ContextApi _context;

        public CommandesController(ContextApi context)
        {
            _context = context;
        }

        // GET: Commandes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Commande>>> GetCommandes()
        {
            return await _context.Commandes.ToListAsync();
        }
        // GET: Commandes/Details/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Commande>> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commande = await _context.Commandes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (commande == null)
            {
                return NotFound();
            }

            return commande;
        }
        // POST: Commandes/Create
        [HttpPost]
        public async Task<ActionResult<Commande>> CreateCommande(Commande commande)
        {
            _context.Commandes.Add(commande);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Details), new { id = commande.Id }, commande);
        }
        [HttpGet]
        private bool CommandeExists(int id)
        {
            return _context.Commandes.Any(e => e.Id == id);
        }

        // POST: Commandes/Edit/5
        [HttpPost("{id}")]
        public async Task<IActionResult> Edit(int id, Commande commande)
        {
            if (id != commande.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(commande);
                await _context.SaveChangesAsync();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var commande = _context.Commandes.FirstOrDefault(e => e.Id == id);
            if (commande == null)
            {
                return NotFound();
            }
            _context.Commandes.Remove(commande);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
