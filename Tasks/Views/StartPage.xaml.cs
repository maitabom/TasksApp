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

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        txtBuscar.Focus();
    }
}