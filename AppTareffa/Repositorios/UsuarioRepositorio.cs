using AppTareffa.Data;
using AppTareffa.Model;
using AppTareffa.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AppTareffa.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {

        private readonly TarefasDBContext _dBContext;

        //construtor
        public UsuarioRepositorio(TarefasDBContext TarefasDBContext) 
        {
            _dBContext = TarefasDBContext;
        }


        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return await _dBContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
            
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {

            return await _dBContext.Usuarios.ToListAsync();
        }

        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {

            await _dBContext.Usuarios.AddAsync(usuario);
            await _dBContext.SaveChangesAsync();


            return usuario;
        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuário parac o Id:{id} não foi encontrado no banco de dados");
            }


            usuarioPorId.Name = usuario.Name;
            usuarioPorId.Email = usuario.Email;

            _dBContext.Usuarios.Update(usuarioPorId);
            _dBContext.SaveChangesAsync();

            return usuarioPorId;
        }

        public async Task<bool> Apagar(int id)
        {

            UsuarioModel usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuário parac o Id:{id} não foi encontrado no banco de dados");
            }


            _dBContext.Usuarios.Remove(usuarioPorId);
            _dBContext.SaveChanges();

            return true;
        }
    }
}
