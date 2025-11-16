using ContactModel = UseOfMVVM.Models.Contact;
using UseOfMVVM.ViewModels;


namespace UseOfMVVM.Views;

public partial class ContactsPage : ContentPage
{
	private readonly ContactsViewModel _viewModel;

	public ContactsPage(ContactsViewModel viewModel)
	{
		InitializeComponent();
		_viewModel = viewModel;
		BindingContext = _viewModel;
	}

	private async void OnContactTapped(object sender, ItemTappedEventArgs e)
	{
		if (e.Item is ContactModel contact)
		{
			if (sender is ListView Lv)
				Lv.SelectedItem = null;

			var detailVm = new ContactDetailViewModel
			{
				Contact = contact
			};

			await Navigation.PushAsync(new ContactDetailsPage(detailVm));
		}
	}

	private async void OnAddMoreClicked(object sender, EventArgs e)
	{
		await Navigation.PopAsync();
	}

}