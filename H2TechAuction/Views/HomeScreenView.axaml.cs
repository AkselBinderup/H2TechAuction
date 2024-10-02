using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using H2TechAuction.Models.AuctionModels;
using H2TechAuction.ViewModels;
using System;
using System.Diagnostics;

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
        MainWindowViewModel.Instance?.SetViewModel(new ProfileViewModel());
    }
    private void OpenBidHistory_click(object sender, RoutedEventArgs e)
    {
        MainWindowViewModel.Instance?.SetViewModel(new BidHistoryViewModel());
    }
    private void SetForSale_click(object sender, RoutedEventArgs e)
    {
        MainWindowViewModel.Instance?.SetViewModel(new SetForSaleViewModel());
    }

    private void YourAuctionsSelectionChanged(object sender,  SelectionChangedEventArgs e)
    {
        var dataGrid = sender as DataGrid;
        var selectedItem = dataGrid?.SelectedItem as AuctionItemModel; // Assuming the item type is AuctionViewModel

        if (selectedItem != null)
        {
            MainWindowViewModel.Instance?.SetViewModel(new BuyerOfAuctionViewModel());
        }
    }

    private void CurrentAuctionsSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var dataGrid = sender as DataGrid;
        var selectedItem = dataGrid?.SelectedItem as AuctionItemModel;

        if (selectedItem != null)
        {
            MainWindowViewModel.Instance?.SetViewModel(new BuyerOfAuctionViewModel(selectedItem));
        }
    }
}