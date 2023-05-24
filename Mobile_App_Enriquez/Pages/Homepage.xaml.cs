namespace Mobile_App_Enriquez.Pages;

public partial class Homepage : ContentPage
{
	public Homepage()
	{
		InitializeComponent();
	}

    private async void addproductBTN_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushModalAsync(new AddProductPage());
    }
}