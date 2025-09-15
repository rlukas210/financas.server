using financas.server.Data;
using financas.server.Models;
using Microsoft.AspNetCore.Mvc;

namespace financas.server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartaoController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public CartaoController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cartao>> GetCartaoById(Guid id)
        {
            var cartao = await _appDbContext.Cartoes.FindAsync(id);
            if (cartao == null)
            {
                return NotFound();
            }
            return Ok(cartao);
        }
    }
}