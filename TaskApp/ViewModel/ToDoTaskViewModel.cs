using System.Collections.ObjectModel;

namespace TaskApp.ViewModel;

public class ToDoTaskViewModel : BaseViewModel
{
    ToDoTaskService toDoTaskService;
    public ObservableCollection<ToDoTask> toDoTasks { get; } = new ();

    public ToDoTaskViewModel(ToDoTaskService toDoTaskService)
    {
        title = "ToDoTasks";
        this.toDoTaskService = toDoTaskService;

        GetToDoTasksAsync();
        GetToDoTasksCommand = new Command(async () => await GetToDoTasksAsync());
        GoToNewTaskPageCommand = new Command(async () => await GoToNewToDoTaskPageAsync());
    }

    public Command GetToDoTasksCommand { get; }

    public Command GoToNewTaskPageCommand { get; }

    async Task GoToNewToDoTaskPageAsync()
    {
        await Shell.Current.GoToAsync($"{nameof(NewToDoTaskPage)}");
    }
    async Task GetToDoTasksAsync()
    {
        if (isBusy)
            return;
        try
        {
            isBusy = true;
            var toDoTasks = await toDoTaskService.GetToDoTasks();

            if (this.toDoTasks.Count != 0)
                this.toDoTasks.Clear();

            foreach (var toDoTask in toDoTasks)
                this.toDoTasks.Add(toDoTask);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            await Shell.Current.DisplayAlert("Error!", $"Unable to get toDoTasks: {ex.Message}", "OK");
        }
        finally
        {
            isBusy = false;
        }
    }
}

