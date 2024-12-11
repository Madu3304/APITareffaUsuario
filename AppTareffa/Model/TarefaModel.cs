using AppTareffa.Enums;

namespace AppTareffa.Model
{
    public class TarefaModel
    {

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Descricao { get; set; }
        public StatusTareffa Status { get; set; }

        public int? UsuarioId { get; set; }

        public virtual UsuarioModel? Usuario { get; set; }
    }
}
