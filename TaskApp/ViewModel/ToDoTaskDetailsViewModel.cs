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
        title = "Details";
        GoBackCommand = new Command(async () => await GoBackAsync());
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

    public Command GoBackCommand { get; }

    async Task GoBackAsync()
    {
        isBusy = true;
        await Shell.Current.GoToAsync("..", true);
        isBusy = false;
    }
}
