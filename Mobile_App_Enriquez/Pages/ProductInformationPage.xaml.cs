using Font = Microsoft.Maui.Font;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Alerts;
using static Mobile_App_Enriquez.App;
using Mobile_App_Enriquez.Models;

namespace Mobile_App_Enriquez.Pages;

public partial class ProductInformationPage : ContentPage
{
    private Student product = new();
	public ProductInformationPage()
	{
		InitializeComponent();
	}

   

    private async void BACKBTN_Clicked(object sender, EventArgs e)
    {
		await Navigation.PopModalAsync();
    }

    private async void SAVEBTN_Clicked(object sender, EventArgs e)
    {
        await product.Save(_mainimgResult,
                           _img1Result,
                           _img2Result,
                           _img3Result,
                           _img4Result,
                           _img5Result,
                           _img6Result,
                           Pname.Text,
                           Pdescript.Text,
                           Pprice.Text);
        await DisplayAlert("Hi", "Successfully Added", "OK");
    }
}