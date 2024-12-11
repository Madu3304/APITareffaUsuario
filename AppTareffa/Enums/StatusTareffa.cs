using System.ComponentModel;

namespace AppTareffa.Enums
{
    public enum StatusTareffa
    {

        [Description("A fazer")]
        Afazer = 1,
        [Description("Em andamento")]
        EmAndamento = 2,
        [Description("Concluido")]
        Concluido = 3,
    }
}
