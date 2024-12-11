using AppTareffa.Data;
using AppTareffa.Model;
using AppTareffa.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AppTareffa.Repositorios
{
    public class TarefaRepositorio : ITarefaRepositorio
    {
        private readonly TarefasDBContext _dBContext;

        public TarefaRepositorio(TarefasDBContext TarefasDBContext)
        {
            _dBContext = TarefasDBContext;
        }

        public async Task<TarefaModel> BuscarPorId(int id)
        {
            return await _dBContext.Tarefa
                .Include(x => x.Usuario)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        //.Include(x => x.Usuario) a pessoa que pegar a API vai ver o suario responsáve pela tarefa. 


        public async Task<List<TarefaModel>> BuscarTodosTarefas()
        {
            return await _dBContext.Tarefa
                .Include(x => x.Usuario)
                .ToListAsync();
        }


        public async Task<TarefaModel> Adicionar(TarefaModel tarefa)
        {
          await _dBContext.Tarefa.AddAsync(tarefa);
          await _dBContext.SaveChangesAsync();

            return tarefa;
        }

        public async Task<TarefaModel> Atualizar(TarefaModel tarefa, int id)
        {

            TarefaModel tarefaPorId = await BuscarPorId(id);
            if (tarefaPorId == null)
            {
                throw new Exception($"Tarefa para o Id:{id} não foi encontrado no banco e dados");
            }

            tarefaPorId.Name = tarefa.Name;
            tarefaPorId.Descricao = tarefa.Descricao;
            tarefaPorId.Status = tarefa.Status;
            tarefaPorId.UsuarioId = tarefa.UsuarioId;

            _dBContext.Tarefa.Update(tarefaPorId);
            _dBContext.SaveChangesAsync();
            return tarefaPorId;
        }


        public async Task<bool> Apagar(int id)
        {

            TarefaModel tarefaPorId = await BuscarPorId(id);
            if(tarefaPorId == null)
            {
                throw new Exception($"Tarefa para o Id:{id} não foi encontrado no banco de dados");
            }

            _dBContext.Tarefa.Remove(tarefaPorId);
            _dBContext.SaveChangesAsync();

            return true;
        }
    }
}
