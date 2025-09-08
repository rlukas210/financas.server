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
            var usuarios = await _appDbContext.Usuarios.ToListAsync();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuarios>> GetUsuarioById(Guid id)
        {
            var usuario = await _appDbContext.Usuarios.FindAsync(id);
            if (usuario == null || usuario.Status == StatusUsuario.Inativo)
            {
                return NotFound();
            }
            return Ok(usuario);
        }
    }
}