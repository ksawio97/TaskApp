﻿using Microsoft.Extensions.Logging;

namespace TaskApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

        builder.Services.AddSingleton<ToDoTaskService>();
		builder.Services.AddSingleton<ToDoTaskViewModel>();
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
}