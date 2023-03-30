using TaskApp.Model;

namespace TaskApp.Services;
public class ToDoTaskService
{
    List<ToDoTask> toDoTasks = new ();

    //add here getting data from net but for now add reading from file
    public async Task<List<ToDoTask>> GetToDoTasks()
    {
        return toDoTasks;
    }
}