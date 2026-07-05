using System;
using System.Collections.Generic;

namespace GerenciadorTarefas.API.Entities
{
    public class Projeto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public DateTime DataCriacao { get; set; }
        public List<Tarefa> Tarefas { get; set; } = new List<Tarefa>();
    }
}