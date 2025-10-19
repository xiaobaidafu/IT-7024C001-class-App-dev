using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace login;

public partial class SignupPage : ContentPage
{
	public SignupPage()
	{
		InitializeComponent();
	}
	// a button logic
	private async void OnSignUpClicked(object sender, EventArgs e)
	{	// claer the spage in the message 
		var username = UsernameEntry.Text?.Trim() ?? String.Empty;
		var email = EmailEntry.Text?.Trim() ?? String.Empty;
		var password = PasswordEntry.Text?.Trim() ?? String.Empty;
		var confirm = ConfirmEntry.Text?.Trim() ?? String.Empty;

		//if statement when condition not meet
		if (string.IsNullOrEmpty(username) ||
			string.IsNullOrEmpty(email) ||
			string.IsNullOrEmpty(password) ||
			string.IsNullOrEmpty(confirm))
		{
			ShowError("pls fill all info");
			return;
		}
        // ^check the first character
        // [^@\s]something tat is not @ and Space
        //@[^@\s]  @ must be here
        //\.[^@\s] . must be here
		// $ end of the chatacter
        if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
		{
			ShowError("Email real pls! That is not a email.");
			return;
		}

		if (!string.Equals(password, confirm))
		{
			ShowError("Password match :) pls");
			return;
		}
		// lengthe for password check
		if (password.Length < 6)
		{
			ShowError("Password must be least 6 or more characters");
			return;
		}
		// hide the error in the last sumbit 
		//if everything is ok then the error message not show
		ErrorLabel.IsVisible = false;

		// create a route to the page with info enter
		//since password is not show in next page. 
		// only username and email will show
		var route = $"{nameof(ProfilePage)}" +
					$"?username={Uri.EscapeDataString(username)}" +
					$"&email={Uri.EscapeDataString(email)}";

		//according to appshell.xaml.cs message
		//route to the next page
		await Shell.Current.GoToAsync(route);

	}
	//define a function for error 
	// when error happend show message and show it
	private void ShowError(string message)
	{
		ErrorLabel.Text = message;
		ErrorLabel.IsVisible = true;
	}
}

