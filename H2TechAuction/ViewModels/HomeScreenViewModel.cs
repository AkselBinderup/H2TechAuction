using Avalonia.Collections;
using H2TechAuction.Models.AuctionModels;
using H2TechAuction.Models.DatabaseRepositories;
using H2TechAuction.Models.UserModels;
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
    private ObservableCollection<VisualAuction> _yourAuctions;
    private ObservableCollection<VisualAuction> _currentAuctions;

    public ObservableCollection<VisualAuction> YourAuctions
    {
        get => _yourAuctions;
        private set => this.RaiseAndSetIfChanged(ref _yourAuctions, value); 
    }
    public ReactiveCommand<VisualAuction, Unit> RowSelectedCommand { get; }

    public ObservableCollection<VisualAuction> CurrentAuctions
    {
        get => _currentAuctions;
        private set => this.RaiseAndSetIfChanged(ref _currentAuctions, value); 
    }
    public HomeScreenViewModel()
    {
        AuctionRepository auctionRepo = new();
        var auctionData = auctionRepo.ReadAll(0);
        VehicleRepository vehicleRepo = new();
        
        
        var aucData = new ObservableCollection<VisualAuction>();
        var yourData = new ObservableCollection<VisualAuction>();
        foreach (var auction in auctionData)
        {
            var vehData = vehicleRepo.ReadId(auction.VehicleId);
            var bid = auction.CurrentBid == 0 ? auction.AskingPrice : auction.CurrentBid;
            var currentBidModel = new VisualAuction
            {
                Name = vehData.Name,
                Year = vehData.ModelYear.ToString(),
                CurrentBid = bid.ToString(),
                SellerId = auction.SellerId,
                VehicleId = auction.VehicleId
            };

            if(auction.SellerId == LoginScreenViewModel.User.Id)
            {
                yourData.Add(currentBidModel);
            }
            else
            {
                aucData.Add(currentBidModel);
            }
        }
        
        _yourAuctions = new ObservableCollection<VisualAuction>(yourData);
        _currentAuctions = new ObservableCollection<VisualAuction>(aucData);

        RowSelectedCommand = ReactiveCommand.Create<VisualAuction>(OnRowSelected);
    }
    public void OpenUserProfile()
    {
        MainWindowViewModel.Instance?.SetViewModel(new ProfileViewModel());
    }
    private void OnRowSelected(VisualAuction selectedAuctionItem)
    {
        Debug.WriteLine($"Selected Auction Item: {selectedAuctionItem.Name}");
    }
}
