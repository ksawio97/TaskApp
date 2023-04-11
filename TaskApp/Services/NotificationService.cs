using Plugin.LocalNotification;
using System.Collections.ObjectModel;

namespace TaskApp.Services;

public static class NotificationService
{
    static string ChannelId { get; }

    public static int lowestNotificationId { get; }

    static NotificationService()
    {
        ChannelId = "Tasks";
        lowestNotificationId = 0;
    }

    public static async Task AddNotifications(ObservableCollection<ToDoTask> toDoTasks)
    {
        if (toDoTasks.Count <= 0 || ! await LocalNotificationCenter.Current.AreNotificationsEnabled())
            return;

        foreach (var toDoTask in toDoTasks)
            await AddNotification(toDoTask);

        var notificationGroup = new NotificationRequest
        {
            NotificationId = lowestNotificationId,
            Title = "ToDoTasks",
            Android =
            {
                ChannelId = ChannelId,
                IsGroupSummary = true
            }
        };
        await LocalNotificationCenter.Current.Show(notificationGroup);
    }

    public static async Task AddNotification(ToDoTask toDoTask)
    {
        var notification = new NotificationRequest
        {
            NotificationId = toDoTask.notificationId,
            Title = toDoTask.title,
            Description = toDoTask.description,
            Android =
            {
                ChannelId = ChannelId
            }
        };
        
        await LocalNotificationCenter.Current.Show(notification);
    }

    public static async Task ClearNotifications()
    {
        if (await LocalNotificationCenter.Current.AreNotificationsEnabled())
            LocalNotificationCenter.Current.ClearAll();
    }
}
