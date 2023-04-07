namespace TaskApp;

public static class TitleViewActions
{
    public static void ChangeTheme()
    {
        if (Application.Current.UserAppTheme == AppTheme.Light)
            Application.Current.UserAppTheme = AppTheme.Dark;
        else
            Application.Current.UserAppTheme = AppTheme.Light;
    }
}
