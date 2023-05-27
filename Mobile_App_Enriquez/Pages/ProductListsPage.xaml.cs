using Mobile_App_Enriquez.Models;

namespace Mobile_App_Enriquez.Pages;

public partial class ProductListsPage : ContentPage
{
	private Student products = new();
	public ProductListsPage()
	{
		InitializeComponent();
	}
    protected async override void OnAppearing()
    {
        base.OnAppearing();

        ListAllProperties.ItemsSource = await products.GetAllUsers();
    }
}