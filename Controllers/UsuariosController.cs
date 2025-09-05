using FinancasServer.Data;
using FinancasServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace financas.server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public UsuariosController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        //GET: /api/usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<usuario>>> GetUsuarios()
        {
            return await _appDbContext.usuario
            .Where(u => u.statusUsuario == "ativo")
            .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<usuario>> GetUsuario(int id)
        {
            var usuario = await _appDbContext.usuario.FindAsync(id);

            if (usuario == null || usuario.statusUsuario == "inativo")
            {
                return NotFound();
            }

            return usuario;
        }

        // POST: api/usuarios
        [HttpPost]
        public async Task<ActionResult<usuario>> PostUsuario(usuario usuario)
        {
            _appDbContext.usuario.Add(usuario);
            await _appDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.idUsuario }, usuario);
        }
    }
}