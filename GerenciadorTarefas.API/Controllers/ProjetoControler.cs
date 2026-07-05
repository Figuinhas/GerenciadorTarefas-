using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GerenciadorTarefas.API.Context;
using GerenciadorTarefas.API.Entities;
using System.Threading.Tasks;

namespace GerenciadorTarefas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjetoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProjetoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Criar(Projeto novoProjeto)
        {
            _context.Projetos.Add(novoProjeto);
            await _context.SaveChangesAsync();
            return Ok(novoProjeto);
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var projetos = await _context.Projetos.Include(p => p.Tarefas).ToListAsync();
            return Ok(projetos);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Obter(Guid id)
        {
            var projeto = await _context.Projetos.FindAsync(id);
            if (projeto == null)
            {
                return NotFound(new { message = "Projeto não encontrado." });
            }
            return Ok(projeto);
        }
    }
}