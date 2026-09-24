using Microsoft.AspNetCore.Mvc;
using Models;
using Models.DbContext;

namespace Core.Controllers;

[ApiController]
public class CategoriaController : ControllerBase
{
    private readonly AppDbContext _ctx;

    public CategoriaController(AppDbContext ctx)
    {
        _ctx = ctx;
    }
    
    
    // POST: Cadastro de categoria individual
    [HttpPost, Route("categoria")]
    public IActionResult CadastrarCategoria(Categoria nomeCategoria)
    {
        if (nomeCategoria == null)
            return BadRequest("Não pode ficar em branco");

        _ctx.Categorias.Add(nomeCategoria);
        return Ok(nomeCategoria);
    }
    
    // POST: Cadastro de categorias em lote
    [HttpPost, Route("categorias")]
    public IActionResult CadCatLote(Categoria[] nomesCategoria)
    {
        foreach (var categoria in nomesCategoria)
        {
            if (categoria == null)
                return BadRequest("Não pode ficar em branco, o item " + categoria);
        }
        return Ok(nomesCategoria);
    }
}