using Tasks.Model;
using Tasks.Repositories;

namespace Tasks.Views;

public partial class StartPage : ContentPage
{
    private ITarefaRepository _repository;
    private IList<Tarefa> _tarefas;

    public StartPage()
    {
        InitializeComponent();

        _repository = new TarefaRepository();

        LoadData();
    }

    public void LoadData()
    {
        _tarefas = _repository.GetAll();
        cvTasks.ItemsSource = _tarefas;
        lblEmptyTasks.IsVisible = (_tarefas.Count == 0);
    }

    private void btnAdicionar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new CrudTaskPage());
    }

    private void bdSearch_Tapped(object sender, TappedEventArgs e)
    {
        txtBuscar.Focus();
    }

    private async void imgTrash_Tapped(object sender, TappedEventArgs e)
    {
        var task = (Tarefa?)e.Parameter;

        if (task is not null)
        {
            var confirm = await DisplayAlert("Exclusão de Tarefa", $"Você tem certeza que deseja excluir a tarefa {task.Nome} ?", "Sim", "Não");

            if (confirm)
            {
                _repository.Delete(task);
                LoadData();
            }
        }
    }

    private void chkTarefaConcluida_Tapped(object sender, TappedEventArgs e)
    {
        var task = (Tarefa?)e.Parameter;

        if (task is not null)
        {
            task.Concluido = ((CheckBox)sender).IsChecked;
            
            _repository.Update(task);
        }
    }

    private void slNameDateTask_Tapped(object sender, TappedEventArgs e)
    {
        var task = (Tarefa?)e.Parameter;

        if (task is not null)
        {
            Navigation.PushModalAsync(new CrudTaskPage(task));
        }
    }

    private void txtBuscar_TextChanged(object sender, TextChangedEventArgs e)
    {
        var chave = e.NewTextValue;

        cvTasks.ItemsSource = _tarefas.Where(t => t.Nome.Contains(chave, StringComparison.InvariantCultureIgnoreCase)).ToList();
    }
}