using System.ComponentModel;

namespace TaskApp.View;

public partial class ToDoTaskDetailsPage : ContentPage
{
	public ToDoTaskDetailsPage(ToDoTaskDetailsViewModel viewModel)
	{
		InitializeComponent();

        BindingContext = viewModel;

        viewModel.PropertyChanged += (object sender, PropertyChangedEventArgs args) => CheckIfShowDescription(args.PropertyName, nameof(viewModel.toDoTask));
    }

    private void CheckIfShowDescription(string PropertyName, string expectedName)
	{
        if (PropertyName == expectedName && Description.Text == null)
            Description.IsVisible = false;
    }
}