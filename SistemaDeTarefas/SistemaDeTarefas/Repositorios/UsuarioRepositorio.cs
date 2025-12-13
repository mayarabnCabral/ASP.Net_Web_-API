using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Interfaces;
using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
       
        private readonly SistemaDetarefasDBContext _dbContext; // DbContext para acessar o banco de dados

        
        public UsuarioRepositorio(SistemaDetarefasDBContext sistemaDetarefasDBContext) // Construtor recebe o DbContext via injeção de dependência
        {
            _dbContext = sistemaDetarefasDBContext;
        }

        
        public async Task<UsuarioModel> BuscarPorId(int id) // Busca um usuário pelo ID
        {
            
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id); // Retorna o primeiro usuário que tenha o ID informado ou null se não existir
        }

        
        public async Task<List<UsuarioModel>> BuscarTodosOsUsuarios() // Retorna todos os usuários
        {
            
            return await _dbContext.Usuarios.ToListAsync(); // Converte o DbSet em uma lista assíncrona
        }

        
        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario) // Adiciona um novo usuário
        {
            
            await _dbContext.Usuarios.AddAsync(usuario); // Adiciona o usuário ao DbSet

            
            await _dbContext.SaveChangesAsync(); // Salva as alterações no banco de dados

            
            return usuario; // Retorna o usuário adicionado, agora com o ID gerado pelo banco
        }

        
        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id) // Atualiza um usuário existente
        {
            
            UsuarioModel usuarioPorId = await BuscarPorId(id); // Busca o usuário pelo ID

            
            if (usuarioPorId == null)
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados."); // Se não encontrar, lança exceção

            // Atualiza os campos do usuário
            usuarioPorId.Nome = usuario.Nome; 
            usuarioPorId.Email = usuario.Email;

           
            _dbContext.Usuarios.Update(usuarioPorId); // Marca a entidade como modificada

            
            await _dbContext.SaveChangesAsync(); // Salva as alterações

            
            return usuarioPorId; // Retorna o usuário atualizado
        }

        
        public async Task<bool> Apagar(int id) // Apaga um usuário pelo ID
        {
            
            UsuarioModel usuarioPorId = await BuscarPorId(id); // Busca o usuário pelo ID

            // Se não encontrar, lança exceção
            if (usuarioPorId == null)
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados.");

           
            _dbContext.Usuarios.Remove(usuarioPorId);  // Remove o usuário do DbSet

            
            await _dbContext.SaveChangesAsync(); // Salva as alterações

            
            return true; // Retorna true para indicar sucesso
        }
    }
}
