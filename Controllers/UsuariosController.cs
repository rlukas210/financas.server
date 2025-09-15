using financas.server.Data;
using financas.server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace financas.server.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public UsuariosController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuarios>>> GetUsuarios()
        {
            var usuarios = await _appDbContext.Usuarios
            .Select(u => new Usuarios
            {
                IdUsuario = u.IdUsuario,
                NomeUsuario = u.NomeUsuario,
                EmailUsuario = u.EmailUsuario
             })
            .ToListAsync();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuarios>> GetUsuarioById(Guid id)
        {
            var usuario = await _appDbContext.Usuarios
            .Where (u => u.IdUsuario == id)
            .Select (u => new Usuarios
            {
                IdUsuario = u.IdUsuario,
                NomeUsuario = u.NomeUsuario,
                EmailUsuario = u.EmailUsuario
            })
            .FirstOrDefaultAsync();

            if (usuario == null)
            {
                return NotFound();
            } else if (usuario.Status == StatusUsuario.Inativo)
            {
                return Forbid("Usuário inativo");
            }
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<Usuarios>> CreateUsuario(Usuarios usuario)
        {
            usuario.Status = StatusUsuario.Ativo;
            _appDbContext.Usuarios.Add(usuario);
            await _appDbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUsuarioById), new { id = usuario.IdUsuario }, usuario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsuario(Guid id, Usuarios usuario)
        {
            if (id != usuario.IdUsuario)
            {
                return BadRequest();
            }

            var existingUsuario = await _appDbContext.Usuarios.FindAsync(id);
            if (existingUsuario == null || existingUsuario.Status == StatusUsuario.Inativo)
            {
                return NotFound();
            }

            existingUsuario.NomeUsuario = usuario.NomeUsuario;
            existingUsuario.EmailUsuario = usuario.EmailUsuario;
            existingUsuario.SenhaUsuario = usuario.SenhaUsuario;

            _appDbContext.Entry(existingUsuario).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}