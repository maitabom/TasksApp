using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Model;

namespace Tasks.Repositories;

public interface ITarefaRepository
{
    IList<Tarefa> GetAll();
    Tarefa Get(int id);
    void Insert(Tarefa tarefa);
    void Update(Tarefa tarefa);
    Task Delete(int id);
    void Delete(Tarefa tarefa);
}
