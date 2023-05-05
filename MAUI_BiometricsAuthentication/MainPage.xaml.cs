namespace MAUI_BiometricsAuthentication;

public partial class MainPage : ContentPage
{
	public MainPage(MainViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}

