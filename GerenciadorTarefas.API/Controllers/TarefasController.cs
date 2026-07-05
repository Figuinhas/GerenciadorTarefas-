using Microsoft.AspNetCore.Mvc;
using GerenciadorTarefas.API.Context;
using GerenciadorTarefas.API.Entities;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var tarefas = await _context.Tarefas.ToListAsync();
            return Ok(tarefas);
        }
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Obter(Guid id)
        {
            var tarefa = await _context.Tarefas.FindAsync(id);
            if (tarefa == null)
            {
                return NotFound(new { message = "Tarefa não encontrada." });
            }
            return Ok(tarefa);
        }
    }
}