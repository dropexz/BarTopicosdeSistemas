using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BarAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class PedidoController : ControllerBase
{
    private readonly AppDataContext _context;

    public PedidoController(AppDataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Pedido>>> Get()
    {
        return await _context.Pedidos
            .Include(p => p.Cliente)
            .Include(p => p.Bebida)
            .ToListAsync();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Pedido pedido)
    {
        var cliente = await _context.Clientes.FindAsync(pedido.ClienteId);
        var bebida = await _context.Cardapio.FindAsync(pedido.BebidaId);

        if (cliente == null || bebida == null)
        {
            return NotFound(new { message = "Cliente ou Bebida não encontrado." });
        }

        if (bebida.Alcoolica && cliente.Idade < 18)
        {
            return BadRequest(new { message = "Cliente menor de idade não pode pedir bebida alcoólica." });
        }

        _context.Pedidos.Add(pedido);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Pedido realizado com sucesso!", pedido });
    }
}
