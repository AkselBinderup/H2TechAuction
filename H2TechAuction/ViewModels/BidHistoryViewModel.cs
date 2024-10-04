using Avalonia.Metadata;
using H2TechAuction.Models.AuctionModels;
using H2TechAuction.Models.DatabaseRepositories;
using H2TechAuction.Models.UserModels;
using ReactiveUI;
using System.Collections.ObjectModel;
using System.Security.Cryptography;

namespace H2TechAuction.ViewModels;

public class BidHistoryViewModel : ViewModelBase
{
    private ObservableCollection<CurrentBidModel> _bidHistory;

    public ObservableCollection<CurrentBidModel> BidHistory
    {
        get => _bidHistory;
        private set => this.RaiseAndSetIfChanged(ref _bidHistory, value);
    }
    public BidHistoryViewModel()
    {
        //AuctionRepository repo = new();

        //DBTODO
        
        //var bidHistory = repo.ReadBidHistory(new PrivateUser(""));
        //BidHistory = new ObservableCollection<CurrentBidModel>(bidHistory);
        
        BidHistory =
        [
            new() { Name = "Ford Escort", Year = "1983", Bid = "3.000", FinalBid = "3.500" },
            new() { Name = "Tesla Model 3", Year = "2016", Bid = "800.000", FinalBid = "WON" },
            new() { Name = "Scania R 730 V8", Year = "2019", Bid = "-", FinalBid = "-" },
            new() { Name = "Skoda Octavia", Year = "2008", Bid = "-", FinalBid = "-" }
        ];
    }
}
