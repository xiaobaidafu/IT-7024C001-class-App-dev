using System.Xml.Serialization;
using UseOfMVVM.ViewModels;


namespace UseOfMVVM.Views;

public partial class ContactDetailsPage : ContentPage
{
	public ContactDetailsPage(ContactDetailViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

	private async void OnBackClicked(object sender, EventArgs e)
	{
		await Navigation.PopAsync();
	}
}