namespace SistemaDeTarefas.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }

        public string? Nome { get; set; } // Nome do usuário
        public string? Email { get; set; } // Email do usuário

        public List<TarefaModel> Tarefas { get; set; } = new List<TarefaModel>(); // Relacionanmento com a tabela Tarefas
    }
}
