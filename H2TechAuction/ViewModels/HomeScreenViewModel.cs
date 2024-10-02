using H2TechAuction.Models.AuctionModels;
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
    private ObservableCollection<AuctionItemModel> _yourAuctions;
    private ObservableCollection<AuctionItemModel> _currentAuctions;

    public ObservableCollection<AuctionItemModel> YourAuctions
    {
        get => _yourAuctions;
        private set => this.RaiseAndSetIfChanged(ref _yourAuctions, value); 
    }
    public ReactiveCommand<AuctionItemModel, Unit> RowSelectedCommand { get; }

    public ObservableCollection<AuctionItemModel> CurrentAuctions
    {
        get => _currentAuctions;
        private set => this.RaiseAndSetIfChanged(ref _currentAuctions, value); 
    }
    public HomeScreenViewModel()
    {
        _yourAuctions = new ObservableCollection<AuctionItemModel>
            {
                new () { Name = "Ford Escort", Year = "1983", Bid = "3.000" },
                new () { Name = "Tesla Model 3", Year = "2016", Bid = "3.000" }
            };

        _currentAuctions = new ObservableCollection<AuctionItemModel>
            {
                new () { Name = "Ford Escort", Year = "1983", Bid = "3.000" },
                new () { Name = "Tesla Model 3", Year = "2016", Bid = "3.000" },
                new () { Name = "Scania R 730 V8", Year = "2019", Bid = "3.000" },
                new () { Name = "Skoda Octavia", Year = "2008", Bid = "3.000" }
            };
        RowSelectedCommand = ReactiveCommand.Create<AuctionItemModel>(OnRowSelected);
    }
    public void OpenUserProfile()
    {
        MainWindowViewModel.Instance?.SetViewModel(new ProfileViewModel());
    }
    private void OnRowSelected(AuctionItemModel selectedAuctionItem)
    {
        Debug.WriteLine($"Selected Auction Item: {selectedAuctionItem.Name}");
    }
}
