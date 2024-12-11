using AppTareffa.Model;

namespace AppTareffa.Repositorios.Interfaces
{
    public interface ITarefaRepositorio
    {

        Task<List<TarefaModel>> BuscarTodosTarefas();

        Task<TarefaModel> BuscarPorId(int id);

        Task<TarefaModel> Adicionar(TarefaModel tarefa);

        Task<TarefaModel> Atualizar(TarefaModel tarefa, int id);

        Task<bool> Apagar(int id);
    }
}
