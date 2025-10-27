

namespace DisplayPosts;

public partial class PostsPage : ContentPage
{
	private readonly ApiService _api = new();

	public PostsPage() 
	{
		InitializeComponent();

	}

	protected override async void OnAppearing()
	{
		base.OnAppearing();
		var posts = await _api.GetListAsync();
		PostsView.ItemsSource = posts;
	}


}