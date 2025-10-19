using System.Threading.Tasks;

namespace login;
// An attribute that pass the vlaue with URL in signup page
[QueryProperty(nameof(Username),"username")]
[QueryProperty(nameof(Email),"email")]
public partial class ProfilePage : ContentPage
{
    // an holder for store the info the was passed
	public String Username {  get; set; } = String.Empty;
	public String Email { get; set; }   = String.Empty ;


	public ProfilePage()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        // base.OnAppearing make sure the value is assigned

        base.OnAppearing();
        //$ connect the "text"+ assigned value
        LblUsername.Text = $"Username:{Username}";
        LblEmail.Text = $"Email:{Email}";
        ;
    }


    private async void OnSignOut(object sender, EventArgs e)
    {
        // go to the page that is route in AppShell
		await Shell.Current.GoToAsync("//SignupPage");
    }
}