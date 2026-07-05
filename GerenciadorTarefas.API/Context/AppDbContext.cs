using Microsoft.EntityFrameworkCore;
using GerenciadorTarefas.API.Entities;

namespace GerenciadorTarefas.API.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Tarefa> Tarefas { get; set; }
    }
}