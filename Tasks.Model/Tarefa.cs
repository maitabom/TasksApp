using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Model;

public class Tarefa
{
    public int Id { get; set; }
    public string Nome { get; set; } = String.Empty;
    public string Descricao { get; set; } = String.Empty;
    public DateTime DataPrevisao { get; set; }
    public bool Concluido { get; set; }
    public List<Subtarefa> Subtarefas { get; set; } = new List<Subtarefa>();
}
