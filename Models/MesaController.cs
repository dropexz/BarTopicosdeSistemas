using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BarAPI.Models;

namespace BarAPI.Controllers{

    [Route("api/[controller]")]
    [ApiController]
    public class MesasController : ControllerBase{
        private readonly AppDataContext _context;

        public MesasController(AppDataContext context){
            _context = context;
        }

        // Obter todas as mesas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mesa>>> Get(){

            return await _context.Mesas.ToListAsync();
        }

        // Liberar uma mesa
        [HttpPut("{id}/liberar")]
        public async Task<IActionResult> LiberarMesa(int id){

            var mesa = await _context.Mesas.FindAsync(id);
            if (mesa == null)
                return NotFound(new { message = "Mesa não encontrada." });

            mesa.Ocupada = false;
            await _context.SaveChangesAsync();

            return Ok(new { message = "Mesa liberada com sucesso!" });
        }

        // Cadastrar uma nova mesa
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Mesa mesa){

            _context.Mesas.Add(mesa);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Mesa cadastrada com sucesso!", mesa });
        }

        // Remover uma mesa
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id){
            
            var mesa = await _context.Mesas.FindAsync(id);
            if (mesa == null)
                return NotFound(new { message = "Mesa não encontrada." });

            _context.Mesas.Remove(mesa);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Mesa removida com sucesso!" });
        }
    }
}
