using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Tasks.Model;

public class Tarefa : INotifyPropertyChanged
{
    private bool _concluido;

    public int Id { get; set; }
    public string Nome { get; set; } = String.Empty;
    public string Descricao { get; set; } = String.Empty;
    public DateTime DataPrevisao { get; set; }

    public bool Concluido
    {
        get
        {
            return _concluido;
        }
        set
        {
            _concluido = value;
            OnPropertyChanged(nameof(Concluido));
        }
    }

    public DateTime Criado { get; set; }
    public DateTime Atualizado { get; set; }
    public ObservableCollection<Subtarefa> Subtarefas { get; set; } = new ObservableCollection<Subtarefa>();

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged(string propertyName)
    {
        if (PropertyChanged is not null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
