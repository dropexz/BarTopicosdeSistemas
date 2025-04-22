using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HotelApi.Models;

[Route("api/[controller]")]
[ApiController]
public class CardapioController : ControllerBase
{
    private static List<Bebida> cardapio = new List<Bebida>
    {
        new Bebida { Id = 1, Nome = "Suco de Laranja", Preco = 5.00M, Alcoolica = false },
        new Bebida { Id = 2, Nome = "Refrigerante de Cola", Preco = 6.50M, Alcoolica = false },
        new Bebida { Id = 3, Nome = "Café Expresso", Preco = 4.00M, Alcoolica = false },
        new Bebida { Id = 4, Nome = "Caipirinha", Preco = 12.00M, Alcoolica = true },
        new Bebida { Id = 5, Nome = "Cerveja Pilsen", Preco = 8.00M, Alcoolica = true },
        new Bebida { Id = 6, Nome = "Cup of Jack", Preco = 25.00M, Alcoolica = true },
        new Bebida { Id = 7, Nome = "Cup of Gin", Preco = 20.00M, Alcoolica = true },
        new Bebida { Id = 8, Nome = "Choop 150ml", Preco = 10.00M, Alcoolica = true },
        new Bebida { Id = 9, Nome = "Choop de Vinho", Preco = 15.00M, Alcoolica = true },
        new Bebida { Id = 10, Nome = "Gin + Tonica", Preco = 30.00M, Alcoolica = true }
    };

    [HttpGet]
    public IEnumerable<Bebida> Get()
    {
        return cardapio;
    }

    [HttpGet("alcoolicas")]
    public IEnumerable<Bebida> GetAlcoolicas()
    {
        return cardapio.FindAll(b => b.Alcoolica);
    }

    [HttpGet("nao-alcoolicas")]
    public IEnumerable<Bebida> GetNaoAlcoolicas()
    {
        return cardapio.FindAll(b => !b.Alcoolica);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Bebida bebida)
    {
        bebida.Id = cardapio.Count + 1;
        cardapio.Add(bebida);
        return Ok(new { message = "Bebida adicionada ao cardápio!", cardapio });
    }
}