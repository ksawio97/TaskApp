namespace TaskApp.View;

public partial class ToDoTaskDetailsPage : ContentPage
{
	public ToDoTaskDetailsPage(ToDoTaskDetailsViewModel viewModel)
	{
		InitializeComponent();

        BindingContext = viewModel;
    }
}