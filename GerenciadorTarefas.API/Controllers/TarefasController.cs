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

            var projetoExiste = await _context.Projetos.AnyAsync(p => p.Id == novaTarefa.ProjetoId);

            if (!projetoExiste)
            {
                return BadRequest(new { mensagem = "Não é possível criar a tarefa pois o ProjetoId informado não existe." });
            }
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
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, Tarefa tarefaAtualizada)
        {
            var tarefaBanco = await _context.Tarefas.FindAsync(id);

            if (tarefaBanco == null)
            {
                return NotFound(new { message = "Tarefa não encontrada para atualizar." });
            }

            tarefaBanco.Titulo = tarefaAtualizada.Titulo;
            tarefaBanco.Descricao = tarefaAtualizada.Descricao;
            tarefaBanco.DataVencimento = tarefaAtualizada.DataVencimento;
            tarefaBanco.Status = tarefaAtualizada.Status;

            await _context.SaveChangesAsync();
            return Ok(tarefaBanco);
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Deletar(Guid id)
        {
            var tarefaBanco = await _context.Tarefas.FindAsync(id);
            if (tarefaBanco == null)
            {
                return NotFound(new { message = "Tarefa não encontrada para exclusão." });
            }

            _context.Tarefas.Remove(tarefaBanco);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}