namespace Tasks.Views;

public partial class StartPage : ContentPage
{
	public StartPage()
	{
		InitializeComponent();
	}

    private void btnAdicionar_Clicked(object sender, EventArgs e)
    {
		Navigation.PushModalAsync(new CrudTaskPage());
    }
}