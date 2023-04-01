using System.Text.Json;

namespace TaskApp.Services;
public class ToDoTaskService
{
    public List<ToDoTask> toDoTasks = new ();
    public static readonly string dataPath = "ToDoTasks.json";

    //add here getting data from net but for now add reading from file
    //change it to task later
    public async Task<List<ToDoTask>> GetToDoTasks()
    {
        using var stream = await FileSystem.OpenAppPackageFileAsync(dataPath);
        using var reader = new StreamReader(stream);
        var contents = await reader.ReadToEndAsync();

        toDoTasks = JsonSerializer.Deserialize<List<ToDoTask>>(contents);

        return toDoTasks;
    }
}