using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.DAO;
using Tasks.Model;

namespace Tasks.Repositories;

public class TarefaRepository : ITarefaRepository
{
    private AppTasksContext _context;

    public TarefaRepository()
    {
        _context = new AppTasksContext();
    }

    public void Delete(int id)
    {
        var pivot = Get(id);

        if (pivot != null)
        {
            Delete(pivot);
        }
    }

    public void Delete(Tarefa tarefa)
    {
        _context.Tarefas.Remove(tarefa);
        _context.SaveChanges();
    }

    public Tarefa? Get(int id)
    {
        return _context.Tarefas.Include(s => s.Subtarefas).FirstOrDefault(t => t.Id.Equals(id));
    }

    public IList<Tarefa> GetAll()
    {
        return _context.Tarefas.OrderByDescending(t => t.DataPrevisao).ToList();
    }

    public void Insert(Tarefa tarefa)
    {
        _context.Tarefas.Add(tarefa);
        _context.SaveChanges();
    }

    public void Update(Tarefa tarefa)
    {
        _context.Tarefas.Update(tarefa);
        _context.SaveChanges();
    }
}
