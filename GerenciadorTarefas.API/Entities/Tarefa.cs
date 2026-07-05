using System;

namespace GerenciadorTarefas.API.Entities
{
    public class Tarefa
    {
        
        public Guid Id { get; set;}
        public string Titulo { get; set;} = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        public DateTime? DataVencimento { get; set; }
        public StatusTarefa Status { get; set; } = StatusTarefa.Pendente;
    }
}