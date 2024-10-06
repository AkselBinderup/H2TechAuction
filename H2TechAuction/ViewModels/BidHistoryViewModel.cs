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
        BidHistoryRepository repo = new();

        var bidHistory = repo.ReadAll(LoginScreenViewModel.User.Id);
        BidHistory = new ObservableCollection<CurrentBidModel>(bidHistory);
    }
}
