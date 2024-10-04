using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using H2TechAuction.ViewModels;

namespace H2TechAuction.Views;

public partial class BuyerOfAuctionView : UserControl
{
    public BuyerOfAuctionView()
    {
        InitializeComponent();
        DataContext = new BuyerOfAuctionViewModel();
    }
    private void ReturnToHome_click(object sender, RoutedEventArgs e) =>
      MainWindowViewModel.Instance?.SetViewModel(new HomeScreenViewModel());
}