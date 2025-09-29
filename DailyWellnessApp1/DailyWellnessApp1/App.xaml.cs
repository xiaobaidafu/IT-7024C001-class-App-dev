namespace DailyWellnessApp1;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        MainPage = new NavigationPage(new MainPage()); // going to page 1 
    }
}
