namespace TaskApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(NewToDoTaskPage), typeof(NewToDoTaskPage));
        Routing.RegisterRoute(nameof(ToDoTaskDetailsPage), typeof(ToDoTaskDetailsPage));
    }
}
