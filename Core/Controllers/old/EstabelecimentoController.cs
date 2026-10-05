using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DbContext;

namespace Core.Controllers;

[ApiController]
public class EstabelecimentoController : Controller
{
    private readonly AppDbContext _ctx;

    public EstabelecimentoController(AppDbContext ctx)
    {
        _ctx = ctx;
    }
    
    //POST: Criar um estabelecimento
    [HttpPost, Route("estabelecimento/adicionar")]
    public IActionResult AdicionarEstabelecimento(Estabelecimento estabelecimento)
    {
        //_ctx.Estabelecimentos.Add(estabelecimento);
        return Ok(estabelecimento);
        //return BadRequest("STUB: Não pronto");
    }
    
}