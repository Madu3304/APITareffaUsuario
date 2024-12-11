using AppTareffa.Enums;

namespace AppTareffa.Model
{
    public class UsuarioModel
    {

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public StatusTareffa Status { get; set; }
    }
}
