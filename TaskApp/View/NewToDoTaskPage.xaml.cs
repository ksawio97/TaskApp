namespace TaskApp.View;

public partial class NewToDoTaskPage : ContentPage
{
	public NewToDoTaskPage(NewToDoTaskViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}