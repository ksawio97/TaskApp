using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;
using Plugin.LocalNotification;
using System.Collections.ObjectModel;

namespace TaskApp;

public static class MauiProgram
{
    private static ToDoTaskViewModel _toDoTaskViewModel;

    public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseLocalNotification()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			}).ConfigureLifecycleEvents(AppLifecycle => {
#if ANDROID
         AppLifecycle.AddAndroid(android => android
            .OnStop((activity) => AddNotifications(_toDoTaskViewModel.toDoTasks)));
		AppLifecycle.AddAndroid(android => android
            .OnResume((activity) => OnResume()));
		AppLifecycle.AddAndroid(android => android
            .OnDestroy((activity) => AddNotifications(_toDoTaskViewModel.toDoTasks)));
#endif
            });
        builder.Services.AddSingleton<ToDoTaskService>();
		builder.Services.AddSingleton<ToDoTaskViewModel>(sp =>
		{
            _toDoTaskViewModel = new ToDoTaskViewModel(sp.GetRequiredService<ToDoTaskService>());
			return _toDoTaskViewModel;
        });
        builder.Services.AddSingleton<MainPage>();

        builder.Services.AddTransient<NewToDoTaskViewModel>();
        builder.Services.AddTransient<NewToDoTaskPage>();

        builder.Services.AddTransient<ToDoTaskDetailsViewModel>();
        builder.Services.AddTransient<ToDoTaskDetailsPage>();
#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}

	static void AddNotifications(ObservableCollection<ToDoTask> toDoTasks)
	{
		NotificationService.AddNotifications(toDoTasks);
	}

	static void OnResume()
	{
		NotificationService.ClearNotifications();

    }
}