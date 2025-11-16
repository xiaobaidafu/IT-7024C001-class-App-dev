using UseOfMVVM.Views;

namespace UseOfMVVM;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new NavigationPage(new AddContactPage());
    }
}
