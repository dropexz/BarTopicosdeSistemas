using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BarAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class CardapioController : ControllerBase
{
    private readonly AppDataContext _context;

    public CardapioController(AppDataContext context)
    {
        _context = context;
        SeedData();
    }

    private void SeedData()
    {
        if (!_context.Cardapio.Any())
        {
            var bebidas = new List<Bebida>
            {
                new Bebida { Nome = "Suco de Laranja", Preco = 5.00M, Alcoolica = false },
                new Bebida { Nome = "Refrigerante de Cola", Preco = 6.50M, Alcoolica = false },
                new Bebida { Nome = "Café Expresso", Preco = 4.00M, Alcoolica = false },
                new Bebida { Nome = "Caipirinha", Preco = 12.00M, Alcoolica = true },
                new Bebida { Nome = "Cerveja Pilsen", Preco = 8.00M, Alcoolica = true },
                new Bebida { Nome = "Cup of Jack", Preco = 25.00M, Alcoolica = true },
                new Bebida { Nome = "Cup of Gin", Preco = 20.00M, Alcoolica = true },
                new Bebida { Nome = "Choop 150ml", Preco = 10.00M, Alcoolica = true },
                new Bebida { Nome = "Choop de Vinho", Preco = 15.00M, Alcoolica = true },
                new Bebida { Nome = "Gin + Tonica", Preco = 30.00M, Alcoolica = true }
            };

            _context.Cardapio.AddRange(bebidas);
            _context.SaveChanges();
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Bebida>>> Get()
    {
        return await _context.Cardapio.ToListAsync();
    }

    [HttpGet("alcoolicas")]
    public async Task<ActionResult<IEnumerable<Bebida>>> GetAlcoolicas()
    {
        return await _context.Cardapio.Where(b => b.Alcoolica).ToListAsync();
    }

    [HttpGet("nao-alcoolicas")]
    public async Task<ActionResult<IEnumerable<Bebida>>> GetNaoAlcoolicas()
    {
        return await _context.Cardapio.Where(b => !b.Alcoolica).ToListAsync();
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Bebida bebida)
    {
        _context.Cardapio.Add(bebida);
        await _context.SaveChangesAsync();
        return Ok(new { message = "Bebida adicionada ao cardápio!", bebida });
    }
}