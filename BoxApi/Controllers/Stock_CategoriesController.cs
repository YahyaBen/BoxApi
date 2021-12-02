using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BoxApi.Models;
using Newtonsoft.Json;
using System.Collections;

namespace BoxApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Stock_CategoriesController : Controller
    {
        private readonly ContextApi _context;

        public Stock_CategoriesController(ContextApi context)
        {
            _context = context;
        }

        // GET: Stock_Categories
        [HttpGet]
         public string Index()
        {
            var contextApi = _context.Stocks_Categories.Include(s => s.Stock).ThenInclude(s => s.Stock_Categories).ToList();
            var serialized = JsonConvert.SerializeObject(
    contextApi,
    new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore, Formatting = Formatting.Indented });
            return serialized;
        }

        // GET: Stock_Categories/Details/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stock_Categories = await _context.Stocks_Categories
                .Include(s => s.Categorie.Id == id)
                .Include(s => s.Stock)
                .ToListAsync();
            if (stock_Categories == null)
            {
                return NotFound();
            }

            return (IActionResult)stock_Categories;
        }

    }
}
