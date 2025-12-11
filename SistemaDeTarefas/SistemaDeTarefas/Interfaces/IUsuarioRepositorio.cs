using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Interfaces
{
    public interface IUsuarioRepositorio // Interface que define os métodos obrigatórios para o repositório de Usuário, responsável por acessaro o banco de dados
    {
        Task<List<UsuarioModel>> BuscarTodosOsUsuarios(); // Método para buscar todos os usuários, de maneira assíncrona(Não bloqueia a aplicação enquanto está sendo executada) por conta do Task
        Task<UsuarioModel> BuscarPorId(int id); //Médoto para buscar usuário por id
        Task<UsuarioModel> Adicionar(UsuarioModel usuaroio); // Método para adicionar um novo usuário
        Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id); // Método para atualizar um usuário existente
        Task<bool> Apagar(int id); // Método para excluir usuário
    }
}
