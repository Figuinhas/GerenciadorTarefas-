using Microsoft.AspNetCore.Mvc;
using GerenciadorTarefas.API.Context;
using GerenciadorTarefas.API.Entities;
using System.Threading.Tasks;

namespace GerenciadorTarefas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TarefasController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Criar(Tarefa novaTarefa)
        {
            _context.Tarefas.Add(novaTarefa);
            await _context.SaveChangesAsync();
            return Ok(novaTarefa);
        }
    }
}