using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BarAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class ClienteController : ControllerBase
{
    private readonly AppDataContext _context;

    public ClienteController(AppDataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Cliente>>> Get()
    {
        return await _context.Clientes.ToListAsync();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Cliente cliente)
    {
        if (cliente.Idade < 18)
        {
            return BadRequest(new { message = "Cliente menor de idade! Cadastro permitido, mas o acesso a bebidas alcoólicas será restrito." });
        }

        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();
        return Ok(new { message = "Cliente cadastrado com sucesso!", cliente });
    }
}
