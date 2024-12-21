using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Model;

public class Subtarefa : INotifyPropertyChanged
{
    private bool _concluido;

    public int Id { get; set; }
    public string Nome { get; set; } = String.Empty;

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

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged(string propertyName)
    {
        if (PropertyChanged is not null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
