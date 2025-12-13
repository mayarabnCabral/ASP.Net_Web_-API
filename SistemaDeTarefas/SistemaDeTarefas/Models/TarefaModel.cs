namespace SistemaDeTarefas.Models
{
    public class TarefaModel
    {
        public int Id { get; set; }

        public string? Nome { get; set; } // Nome da tarefa (o ? indica que pode ser nulo) 

        public string? Descricao { get; set; } // Descrição da tarefa

        public int Status { get; set; } // Status da tarefa (0 - Pendente, 1 - Em Progresso, 2 - Concluída)

        // Relacionanmento com a tabela Usuario
        // Relacionanmento com a tabela Usuario
        public int UsuarioId { get; set; }
        public UsuarioModel Usuario { get; set; }
    }
}
