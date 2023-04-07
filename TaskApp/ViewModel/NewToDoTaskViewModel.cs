namespace TaskApp.ViewModel;

public class NewToDoTaskViewModel :BaseViewModel
{
    ToDoTaskViewModel _ToDoTaskViewModel;

    string _taskTitle;

    string _taskDescription;

    public string taskTitle
    {
        get => _taskTitle;
        set 
        {
            _taskTitle = value;
            OnPropertyChanged();
        }
    }

    public string taskDescription
    {
        get => _taskDescription;
        set
        {
            _taskDescription = value;
            OnPropertyChanged();
        }
    }

    public NewToDoTaskViewModel(ToDoTaskViewModel view)
    {
        _ToDoTaskViewModel = view;

        title = "Create new ToDoTask";

        AddToDoTaskCommand = new Command(async () => await AddToDoTaskAsync());
        ChangeThemeCommand = 
            new Command(() => 
            {
                if (isBusy)
                    return;
                isBusy = true;
                TitleViewActions.ChangeTheme();
                isBusy = false;
            });
    }

    public Command AddToDoTaskCommand { get; }
    async Task AddToDoTaskAsync()
    {
        if (isBusy)
            return;
        isBusy = true;

        if (!string.IsNullOrEmpty(taskTitle))
            _ToDoTaskViewModel.toDoTasks.Add(
                new ToDoTask 
                { 
                    title = taskTitle, 
                    description = taskDescription 
                });

        await Shell.Current.GoToAsync("..", true);
        isBusy = false;
    }
}
