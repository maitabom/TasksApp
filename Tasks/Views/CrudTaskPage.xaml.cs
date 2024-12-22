using Tasks.Model;
using Tasks.Repositories;

namespace Tasks.Views;

public partial class CrudTaskPage : ContentPage
{
    private readonly ITarefaRepository repository;
    private Tarefa Tarefa { get; set; }

    public CrudTaskPage()
    {
        InitializeComponent();
        repository = new TarefaRepository();
        Tarefa = new Tarefa();

        BindableLayout.SetItemsSource(slSubtarefas, Tarefa.Subtarefas);
    }

    public CrudTaskPage(Tarefa tarefa)
    {
        repository = new TarefaRepository();
        Tarefa = repository.Get(tarefa.Id) ?? new Tarefa();

        InitializeComponent();
        LoadData();
    }

    private void btnClose_Clicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }

    private void btnSalvar_Clicked(object sender, EventArgs e)
    {
        GetFormData();
        
        if(ValidationData())
        {
            SaveData();
            RefreshData();
            Navigation.PopModalAsync();
        }
    }

    private async void btnAddSubtask_Clicked(object sender, EventArgs e)
    {
        var stepName = await DisplayPromptAsync("Etapa (Subtarefa)", "Digite o nome da etapa (subtarefa)", "Adicionar", "Cancelar");

        if (!String.IsNullOrEmpty(stepName))
        {
            Tarefa.Subtarefas.Add(new Subtarefa { Nome = stepName, Concluido = false });
        }
    }

    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);
        dpTaskDate.WidthRequest = width - 30;
    }

    private void btnExcluirSubtarefa_Click(object sender, TappedEventArgs e)
    {
        var marcado = (Subtarefa?)e.Parameter;

        if (marcado is not null)
        {
            Tarefa.Subtarefas.Remove(marcado);
        }
    }

    private void LoadData()
    {
        txtTituloTarefa.Text = Tarefa.Nome;
        txtDescricao.Text = Tarefa.Descricao;
        dpTaskDate.Date = Tarefa.DataPrevisao;
        
        BindableLayout.SetItemsSource(slSubtarefas, Tarefa.Subtarefas);
    }

    private void GetFormData()
    {
        Tarefa.Nome = txtTituloTarefa.Text;
        Tarefa.Descricao = txtDescricao.Text;
        Tarefa.DataPrevisao = dpTaskDate.Date;
        Tarefa.Criado = DateTime.Now;
        Tarefa.Concluido = false;
    }

    private bool ValidationData()
    {
        bool valid = true;

        lblErroTitulo.IsVisible = false;
        lblErroDescricao.IsVisible = false;

        if (String.IsNullOrWhiteSpace(Tarefa.Nome))
        {
            lblErroTitulo.IsVisible = true;
            valid = false;
        }

        if (String.IsNullOrWhiteSpace(Tarefa.Descricao))
        {
            lblErroDescricao.IsVisible = true;
            valid = false;
        }

        return valid;
    }

    private void SaveData()
    {
        if (Tarefa.Id == 0)
        {
            repository.Insert(Tarefa);
        }
        else
        {
            repository.Update(Tarefa);
        }
    }

    private void RefreshData()
    {
        var navigationPage = App.Current.MainPage as NavigationPage;

        if (navigationPage is not null)
        {
            var startPage = (StartPage)navigationPage.CurrentPage;
            startPage.LoadData();
        }
    }
}