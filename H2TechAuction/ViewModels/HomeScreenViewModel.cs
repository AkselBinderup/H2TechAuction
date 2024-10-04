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
        AuctionRepository repo = new();
        var data = repo.ReadAll(0);

        //DBTODO
        //_yourAuctions = new ObservableCollection<CurrentBidModel>(data)

        _yourAuctions =
            [
                new () { Name = "Ford Escort", Year = "1983", Bid = "3.000" },
                new () { Name = "Tesla Model 3", Year = "2016", Bid = "3.000" }
            ];

        _currentAuctions =
            [
                new () { Name = "Ford Escort", Year = "1983", Bid = "3.000" },
                new () { Name = "Tesla Model 3", Year = "2016", Bid = "3.000" },
                new () { Name = "Scania R 730 V8", Year = "2019", Bid = "3.000" },
                new () { Name = "Skoda Octavia", Year = "2008", Bid = "3.000" }
            ];
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
