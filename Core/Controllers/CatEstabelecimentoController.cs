using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DbContext;

namespace Core.Controllers;

public class CatEstabelecimentoController : Controller
{
    private readonly AppDbContext _ctx;

    public CatEstabelecimentoController(AppDbContext ctx)
    {
        _ctx = ctx;
    }
    
    //POST: Criar categoria individualmente
    public IActionResult CadastrarCatEstabelecimento(CategoriaEstabelecimento catEstabelecimento)
    {
        if (catEstabelecimento == null)
        {
            return BadRequest("Não pode ficar em branco");
        }
        
        _ctx.Add(catEstabelecimento);
        _ctx.SaveChanges();
        
        return Ok(catEstabelecimento);
    }
    
    //GET: Categorias de estabelecimento
    [HttpGet, Route("estabelecimento/categoria")]
    public IActionResult ListarCatEstabelecimento()
    {
        return Ok(_ctx.CatEstabelecimento.ToList());
    }
}