namespace Tasks.Views;

public partial class CrudTaskPage : ContentPage
{
	public CrudTaskPage()
	{
		InitializeComponent();
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
    }
}