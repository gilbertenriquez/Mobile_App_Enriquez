using Mobile_App_Enriquez.Models;
using Plugin.Connectivity;
using System.Net.NetworkInformation;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using Toast = CommunityToolkit.Maui.Alerts.Toast;

namespace Mobile_App_Enriquez.Pages;

public partial class ProductListsPage : ContentPage
{
    CancellationTokenSource cancellationTokenSource = new();
    private Student products = new();
    public ProductListsPage()
    {
        InitializeComponent();
        Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;

    }

    private async void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
    {
        if (e.NetworkAccess != NetworkAccess.Internet)
        {
            nointernet.IsVisible = true;
            var toast = Toast.Make("You may have no internet connection!", ToastDuration.Long, 12);
            await toast.Show(cancellationTokenSource.Token);
        }
        else
        {
            nointernet.IsVisible = false;
            var toast = Toast.Make("Internet connection Restored!", ToastDuration.Long, 12);
            await toast.Show(cancellationTokenSource.Token);
        }
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();      
        ListAllProperties.ItemsSource = await products.GetAllUsers();
    }

    private void IC_check()
    {
        if (CrossConnectivity.Current.IsConnected)
        {
            nointernet.IsVisible = false;
            return;
        }
        else
        {
            nointernet.IsVisible = true;
            return;
        }
    }

    private void refreshView_Refreshing(object sender, EventArgs e)
    {

    }
}

