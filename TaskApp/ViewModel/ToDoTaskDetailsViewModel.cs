namespace TaskApp.ViewModel;

[QueryProperty(nameof(toDoTask), "toDoTask")]
public class ToDoTaskDetailsViewModel : BaseViewModel
{
    ToDoTask _toDoTask;

    public ToDoTask toDoTask
    {
        get => _toDoTask;
        set
        {
            _toDoTask = (ToDoTask)value;
            OnPropertyChanged();
        }
    }
    public ToDoTaskDetailsViewModel()
    {
        title = "Edit Task";
        GoBackCommand = new Command(async () => await GoBackAsync());
    }

    public Command GoBackCommand { get; }

    async Task GoBackAsync()
    {
        isBusy = true;
        await Shell.Current.GoToAsync("..", true);
        isBusy = false;
    }
}
