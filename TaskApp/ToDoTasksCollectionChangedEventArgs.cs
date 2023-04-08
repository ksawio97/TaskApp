namespace TaskApp;

public class ToDoTasksCollectionChangedEventArgs : EventArgs
{
    public ToDoTask toDoTask; 
    public ToDoTasksCollectionChangedEventArgs(ToDoTask toDoTask)
    {
        this.toDoTask = toDoTask;
    }
}