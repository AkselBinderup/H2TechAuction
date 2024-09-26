using H2TechAuction.Models.AuctionModels;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

    public ObservableCollection<AuctionItemModel> CurrentAuctions
    {
        get => _currentAuctions;
        private set => this.RaiseAndSetIfChanged(ref _currentAuctions, value); 
    }
    public HomeScreenViewModel()
    {
        YourAuctions = new ObservableCollection<AuctionItemModel>
            {
                new AuctionItemModel { Name = "Ford Escort", Year = "1983", Bid = "3.000" },
                new AuctionItemModel { Name = "Tesla Model 3", Year = "2016", Bid = "3.000" }
            };

        CurrentAuctions = new ObservableCollection<AuctionItemModel>
            {
                new AuctionItemModel { Name = "Ford Escort", Year = "1983", Bid = "3.000" },
                new AuctionItemModel { Name = "Tesla Model 3", Year = "2016", Bid = "3.000" },
                new AuctionItemModel { Name = "Scania R 730 V8", Year = "2019", Bid = "3.000" },
                new AuctionItemModel { Name = "Skoda Octavia", Year = "2008", Bid = "3.000" }
            };
    }


}
