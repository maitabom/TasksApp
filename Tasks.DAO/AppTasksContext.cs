using Microsoft.EntityFrameworkCore;
using Tasks.Model;

namespace Tasks.DAO;

public class AppTasksContext : DbContext
{
    public DbSet<Tarefa> Tarefas { get; set; }
    public DbSet<Subtarefa> Subtarefas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        var databaseName = "apptask.db";
        var databasePath = Path.Combine(folderPath, databaseName);
        
        optionsBuilder.UseSqlite(databasePath);
    }
}
