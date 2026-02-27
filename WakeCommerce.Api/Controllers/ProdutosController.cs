using Microsoft.AspNetCore.Mvc;
using WakeCommerce.Api.Entities;
using WakeCommerce.Api.Services;

namespace WakeCommerce.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutosController : ControllerBase
{
    private readonly IProdutoService _service;

    public ProdutosController(IProdutoService service)
    {
        _service = service;
    }

    // GET: api/produtos
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] string? nome, [FromQuery] string? ordem)
    {
        var produtos = await _service.ObterTodosAsync(nome, ordem);
        return Ok(produtos);
    }

    // GET: api/produtos/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var produto = await _service.ObterPorIdAsync(id);

        if (produto == null)
            return NotFound();

        return Ok(produto);
    }

    // POST: api/produtos
    [HttpPost]
    public async Task<IActionResult> Create(Produto produto)
    {
        await _service.AdicionarAsync(produto);
        return CreatedAtAction(nameof(GetById), new { id = produto.Id }, produto);
    }

    // PUT: api/produtos/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Produto produto)
    {
        if (id != produto.Id)
            return BadRequest();

        await _service.AtualizarAsync(produto);
        return NoContent();
    }

    // DELETE: api/produtos/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeletarAsync(id);
        return NoContent();
    }
}