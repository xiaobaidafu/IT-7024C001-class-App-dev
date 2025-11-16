using UseOfMVVM.ViewModels;

namespace UseOfMVVM.Views;

public partial class AddContactPage : ContentPage
{
	private readonly ContactsViewModel _viewModel;

	public AddContactPage()
	{
		InitializeComponent();

		_viewModel = new ContactsViewModel();
		BindingContext = _viewModel;
	}

	private async void OnSaveAndViewClicked(object sender, EventArgs e)
	{
		if (_viewModel.Contacts.Count>0)
		{
			await Navigation.PushAsync(new ContactsPage(_viewModel));
		}
	}
}