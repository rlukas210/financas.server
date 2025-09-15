using financas.server.Data;
using financas.server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace financas.server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public CategoriasController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categorias>>> GetCategorias()
        {
            var categorias = await _appDbContext.Categorias.ToListAsync();
            return Ok(categorias);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Categorias>> GetCategoriaById(int id)
        {
            var categoria = await _appDbContext.Categorias.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return Ok(categoria);
        }

        /* [HttpPost]
         public async Task<ActionResult<Categorias>> CreateCategoria(Categorias categoria)
         {
             _appDbContext.Categorias.Add(categoria);
             await _appDbContext.SaveChangesAsync();
             return CreatedAtAction(nameof(GetCategoriaById), new { id = categoria.IdCategoria }, categoria);
         }*/

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Categorias>>> CreateCategoria(List<Categorias> categoria)
        {
            if (categoria == null || !categoria.Any())
            {
                return BadRequest("A lista de categorias não pode ser nula ou vazia.");
            }
            await _appDbContext.Categorias.AddRangeAsync(categoria);
            await _appDbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCategoriaById), new { id = categoria.First().IdCategoria }, categoria);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategoria(int id, Categorias categoria)
        {
            if (id != categoria.IdCategoria)
            {
                return BadRequest();
            }

            _appDbContext.Entry(categoria).State = EntityState.Modified;

            try
            {
                await _appDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_appDbContext.Categorias.Any(e => e.IdCategoria == id))
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
    }
}