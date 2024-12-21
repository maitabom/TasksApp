using Tasks.Model;

namespace Tasks.Views;

public partial class CrudTaskPage : ContentPage
{
    private Tarefa Tarefa { get; set; }

    public CrudTaskPage()
    {
        InitializeComponent();
        Tarefa = new Tarefa();

        BindableLayout.SetItemsSource(slSubtarefas, Tarefa.Subtarefas);
    }

    private void btnClose_Clicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }

    private void btnSalvar_Clicked(object sender, EventArgs e)
    {
        Navigation.PopModalAsync();
    }

    private async void btnAddSubtask_Clicked(object sender, EventArgs e)
    {
        var stepName = await DisplayPromptAsync("Etapa (Subtarefa)", "Digite o nome da etapa (subtarefa)", "Adicionar", "Cancelar");

        if (!String.IsNullOrEmpty(stepName))
        {
            Tarefa.Subtarefas.Add(new Subtarefa({ Nome = stepName, Concluido = false });
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
}