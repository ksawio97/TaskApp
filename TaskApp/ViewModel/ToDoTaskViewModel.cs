using System.Collections.ObjectModel;
using TaskApp.Model;
using TaskApp.Services;

namespace TaskApp.ViewModel;

class ToDoTaskViewModel : BaseViewModel
{
    ToDoTaskService toDoTaskService;
    public ObservableCollection<ToDoTask> toDoTasks { get; } = new ();

    public ToDoTaskViewModel(ToDoTaskService toDoTaskService)
    {
        title = "ToDoTaskFinder";
        this.toDoTaskService = toDoTaskService;
    }
}

