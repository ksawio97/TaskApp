namespace TaskApp;

public partial class App : Application
{
	public App(ToDoTaskViewModel view)
	{
		InitializeComponent();

        MainPage = new AppShell();
		
    }
}
