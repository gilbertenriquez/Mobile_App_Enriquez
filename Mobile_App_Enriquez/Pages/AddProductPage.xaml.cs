using Font = Microsoft.Maui.Font;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Alerts;
using Plugin.Connectivity;
using static Mobile_App_Enriquez.App;
using Mobile_App_Enriquez.Pages;
using Mobile_App_Enriquez.Models;

namespace Mobile_App_Enriquez.Pages;

public partial class AddProductPage : ContentPage
{
    FileResult _mainimage;
    
    CancellationTokenSource cancellationTokenSource = new ();
    Student uploads = new();
	public AddProductPage()
	{
		InitializeComponent();
	}

    private async void addimageBTN_Clicked(object sender, EventArgs e)
    {
        var result = await FilePicker.PickAsync(new PickOptions
        {
            PickerTitle = "Select main image",
            FileTypes = FilePickerFileType.Images
        });
        if (result == null) return;

        FileInfo fi = new(result.FullPath);
        var size = fi.Length;

        if (size > 524288)
        {
            var snackbarOptions = new SnackbarOptions
            {
                BackgroundColor = Color.FromRgb(32, 32, 40),
                TextColor = Colors.WhiteSmoke,
                ActionButtonTextColor = Colors.White,
                CornerRadius = new CornerRadius(10),
                Font = Font.SystemFontOfSize(10),
                ActionButtonFont = Font.SystemFontOfSize(10)
            };
            const string text = "The image you have selected is more than 0.50MB please ensure that the size of the image is less than the maximum size. Thank you!";
            const string actionButtonText = "Got it!";
            var duration = TimeSpan.FromSeconds(10);
            var snackbar = Snackbar.Make(text, null, actionButtonText, duration, snackbarOptions);

            await snackbar.Show(cancellationTokenSource.Token);
            return;
        }
        var stream = await result.OpenReadAsync();
        App._mainimgResult = result;
        mainimage.Source = ImageSource.FromStream(() => stream);

        IC_check();
        progressLoading.IsVisible = false;

    }
    private async void IC_check()
    {
        if (CrossConnectivity.Current.IsConnected)
        {
            return;
        }
        await DisplayAlert("Alert", "No Internet Connection", "OK!");
        return;
    }

    private async void addsupportimgBTN_Clicked(object sender, EventArgs e)
    {
        var ctr = 0;
        var results = await FilePicker.PickMultipleAsync();
        foreach (var result in results)
        {
            progressLoading.IsVisible = true;
            ctr++;
            switch (ctr)
            {
                //first image
                case 1:
                    {
                        _img1Result = result;
                        var stream = await result.OpenReadAsync();
                        img1.Source = ImageSource.FromStream(() => stream);
                        break;
                    }
                case 2:
                    {
                        _img2Result = result;
                        var stream = await result.OpenReadAsync();
                        img2.Source = ImageSource.FromStream(() => stream);
                        break;
                    }
                case 3:
                    {
                        _img3Result = result;
                        var stream = await result.OpenReadAsync();
                        img3.Source = ImageSource.FromStream(() => stream);
                        break;
                    }
                case 4:
                    {
                        _img4Result = result;
                        var stream = await result.OpenReadAsync();
                        img4.Source = ImageSource.FromStream(() => stream);
                        break;
                    }
                case 5:
                    {
                        _img5Result = result;
                        var stream = await result.OpenReadAsync();
                        img5.Source = ImageSource.FromStream(() => stream);
                        break;
                    }
                case 6:
                    {
                        _img6Result = result;
                        var stream = await result.OpenReadAsync();
                        img6.Source = ImageSource.FromStream(() => stream);
                        break;
                    }

            }
        }
        progressLoading.IsVisible = false;
    }


    private async void NEXTBTN_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new ProductInformationPage());
    }

    private async void BTNBACK_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}