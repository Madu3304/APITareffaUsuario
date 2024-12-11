using AppTareffa.Data.Map;
using AppTareffa.Model;
using Microsoft.EntityFrameworkCore;

namespace AppTareffa.Data
{
    public class TarefasDBContext : DbContext
    {

        public TarefasDBContext(DbContextOptions<TarefasDBContext>  options) : base(options) 
        {
        }


        public DbSet<UsuarioModel> Usuarios { get; set; }
        
        public DbSet<TarefaModel> Tarefa { get; set; }

        //metodo
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
