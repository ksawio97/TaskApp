using System.Collections.ObjectModel;
using System.Text.Json;

namespace TaskApp.Services;
public class ToDoTaskService
{
    public static readonly string toDoTasksData = "ToDoTasks.json";
    public static readonly string appDataDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

    //add here getting data from net but for now add reading from file
    //change it to task later
    public async Task<List<ToDoTask>> GetToDoTasks()
    {
        string targetFile = Path.Combine(appDataDir, toDoTasksData);
        if (!File.Exists(targetFile))
            return new List<ToDoTask>();

        using var stream = File.OpenRead(targetFile);
        using var reader = new StreamReader(stream);
        var contents = await reader.ReadToEndAsync();

        return JsonSerializer.Deserialize<List<ToDoTask>>(contents);
    }

    public async Task SaveToDoTasks(ObservableCollection<ToDoTask> toDoTasks)
    {
        try
        {
            string targetFile = Path.Combine(appDataDir, toDoTasksData);

            using var stream = File.Open(targetFile, FileMode.Create, FileAccess.Write, FileShare.None);
            using var writer = new StreamWriter(stream);
            var contents = JsonSerializer.Serialize(toDoTasks.ToList());

            await writer.WriteAsync(contents);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            await Shell.Current.DisplayAlert("Error!", $"Unable to save toDoTasks: {ex.Message}", "OK");
        }
    }
}