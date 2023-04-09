using System.Collections.ObjectModel;

namespace TaskApp.ViewModel;

public class ToDoTaskViewModel : BaseViewModel
{
    public ToDoTaskService toDoTaskService { get; private set; }

    public ObservableCollection<ToDoTask> toDoTasks { get; } = new ();

    //event may be usefull in future
    public EventHandler<ToDoTasksCollectionChangedEventArgs> toDoTasksCollectionChanged;

    public ToDoTaskViewModel(ToDoTaskService toDoTaskService)
    {
        title = "ToDoTasks";
        this.toDoTaskService = toDoTaskService;

        GetToDoTasksAsync();

        GoToNewTaskPageCommand = new Command(async () => await GoToNewToDoTaskPageAsync());
        GoToToDoTaskDetailsCommand = new Command<ToDoTask>(async (ToDoTask toDoTask) => await GoToToDoTaskDetailsAsync(toDoTask));
        ChangeThemeCommand = new Command(() => { TitleViewActions.ChangeTheme(); } );
        DeleteTaskCommand = new Command<ToDoTask>(DeleteTask);

        toDoTasksCollectionChanged += async (sender, args) => { await toDoTaskService.SaveToDoTasks(toDoTasks); };
    }

    public Command GoToNewTaskPageCommand { get; }

    public Command<ToDoTask> DeleteTaskCommand { get; }

    public Command<ToDoTask> GoToToDoTaskDetailsCommand { get; }

    void DeleteTask(ToDoTask toDoTask)
    {
        if (toDoTasks.Contains(toDoTask))
        {
            toDoTasks.Remove(toDoTask);
            var args = new ToDoTasksCollectionChangedEventArgs(toDoTask: toDoTask);
            toDoTasksCollectionChanged(this, args);
        }
    }

    async Task GoToToDoTaskDetailsAsync(ToDoTask toDoTask)
    {
        if (isBusy)
            return;

        isBusy = true;
        if (toDoTask is null)
            return;
        await Shell.Current.GoToAsync($"{nameof(ToDoTaskDetailsPage)}", true,
            new Dictionary<string, object>
            {
                { "toDoTask", toDoTask }
            });
        isBusy = false;
    }
    async Task GoToNewToDoTaskPageAsync()
    {
        if (isBusy)
            return;

        isBusy = true;
        await Shell.Current.GoToAsync($"{nameof(NewToDoTaskPage)}");
        isBusy = false;
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
            
            if (toDoTasks.Count != 0)
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