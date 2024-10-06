using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using H2TechAuction.Models.AuctionModels;
using H2TechAuction.Models.DatabaseRepositories;
using H2TechAuction.ViewModels;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

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
    private void AcceptedBid(object sender, RoutedEventArgs e)
    {

    }
    private void PlacedBid(object sender, RoutedEventArgs e)
    {
        if(DataContext is BuyerOfAuctionViewModel viewModel) 
        {
            viewModel.DeterminePlaceBTNVisibility = false;
            viewModel.DetermineConfirmVisibility = true;
            viewModel.BAIsVisible = true;
            
        }
    }
    private void Confirm(object sender, RoutedEventArgs e)
    {
        if (DataContext is BuyerOfAuctionViewModel viewModel)
        {
            viewModel.DeterminePlaceBTNVisibility = false;
            viewModel.DetermineConfirmVisibility = true;
            viewModel.BAIsVisible = true;

            string? name = viewModel.CarName;
            decimal bidAmount = viewModel.BidAmount;
            string currentBidValue = Regex.Replace(viewModel.CurrentBid, "[^0-9.]", "");
            decimal.TryParse(currentBidValue, out decimal currentBid);

            if (bidAmount < currentBid)
            {

            }
            else
            {
                var model = new CurrentBidModel
                {
                    Name = name,
                    CurrentBid = bidAmount.ToString(),
                    AuctionId = viewModel.AuctionId
                };
                BidHistoryRepository repo = new();
                repo.Create(model);
            }

        }

    }
}