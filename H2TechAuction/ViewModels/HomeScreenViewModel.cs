using Avalonia.Collections;
using H2TechAuction.Models.AuctionModels;
using H2TechAuction.Models.DatabaseRepositories;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace H2TechAuction.ViewModels;

public class HomeScreenViewModel : ViewModelBase
{
    private ObservableCollection<CurrentBidModel> _yourAuctions;
    private ObservableCollection<CurrentBidModel> _currentAuctions;

    public ObservableCollection<CurrentBidModel> YourAuctions
    {
        get => _yourAuctions;
        private set => this.RaiseAndSetIfChanged(ref _yourAuctions, value); 
    }
    public ReactiveCommand<CurrentBidModel, Unit> RowSelectedCommand { get; }

    public ObservableCollection<CurrentBidModel> CurrentAuctions
    {
        get => _currentAuctions;
        private set => this.RaiseAndSetIfChanged(ref _currentAuctions, value); 
    }
    public HomeScreenViewModel()
    {
        BidHistoryRepository bidRepo = new();
        var data = bidRepo.ReadAll(LoginScreenViewModel.User.Id);
        AuctionRepository auctionRepo = new();
        var auctionData = auctionRepo.ReadAll(0);

        //DBTODO
        _yourAuctions = new ObservableCollection<CurrentBidModel>(data);

        var aucData = new ObservableCollection<CurrentBidModel>();
        foreach (var auction in auctionData)
        {
            // Create a new instance of CurrentBidModel
            var currentBidModel = new CurrentBidModel
            {
                Name = auction.Vehicle.Name, 
                Year = auction.Vehicle.ModelYear.ToString(),
                Bid = auction.CurrentBid.ToString() 
            };

            aucData.Add(currentBidModel);
        }

        _currentAuctions = new ObservableCollection<CurrentBidModel>(aucData);

        RowSelectedCommand = ReactiveCommand.Create<CurrentBidModel>(OnRowSelected);
    }
    public void OpenUserProfile()
    {
        MainWindowViewModel.Instance?.SetViewModel(new ProfileViewModel());
    }
    private void OnRowSelected(CurrentBidModel selectedAuctionItem)
    {
        Debug.WriteLine($"Selected Auction Item: {selectedAuctionItem.Name}");
    }
}
