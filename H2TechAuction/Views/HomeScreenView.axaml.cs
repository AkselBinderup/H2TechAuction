using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using H2TechAuction.Models.AuctionModels;
using H2TechAuction.ViewModels;

namespace H2TechAuction.Views;

public partial class HomeScreenView : UserControl
{
    public HomeScreenView()
    {
        InitializeComponent();
        DataContext = new HomeScreenViewModel();
    }
    private void OpenUserProfile_click(object sender, RoutedEventArgs e)
    {
        MainWindowViewModel.Instance.SetViewModel(new ProfileViewModel());
    }
    private void OpenBidHistory_click(object sender, RoutedEventArgs e)
    {
        MainWindowViewModel.Instance.SetViewModel(new BidHistoryViewModel());
    }
    private void SetForSale_click(object sender, RoutedEventArgs e)
    {
        MainWindowViewModel.Instance.SetViewModel(new SetForSaleViewModel());
    }
}