using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Data
{
    public class SistemaDetarefasDBContext : DbContext // DbContext → Classe responsável por fazer a comunicação entre a aplicação e o banco de dados
    {
        public SistemaDetarefasDBContext(DbContextOptions<SistemaDetarefasDBContext> Optinons) : base(Optinons) { }// Construtor que recebe as configurações do banco (string de conexão, provedor etc.)
        // Essas configurações são repassadas para a classe base DbContext.
        // DbSet -> Representa uma tabela no banco de dados.
        // Cada DbSet se torna uma tabela e cada objeto de UsuarioModel será um registro.
        public DbSet<UsuarioModel> Usuarios { get; set; } // Representa a tabela de usuários no banco de dados
        public DbSet<TarefaModel> Tarefas { get; set; } // Representa a tabela de tarefas no banco de dados

        protected override void OnModelCreating(ModelBuilder modelBuilder) // Configurações os relacionamentos da entidade
        {
            modelBuilder.Entity<UsuarioModel>()
                .HasMany(static u => u.Tarefas) // Um para muitos (1:N)
                .WithOne(t => t.Usuario)// Muitos para um (N:1)
                .HasForeignKey(t => t.UsuarioId); // Chave estrangeira
            base.OnModelCreating(modelBuilder); // Importante: sempre chamar o método da classe base
        }
    }
}
