namespace TaskApp.View;

public partial class MainPage : ContentPage
{
    public MainPage(ToDoTaskViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
    }
}

