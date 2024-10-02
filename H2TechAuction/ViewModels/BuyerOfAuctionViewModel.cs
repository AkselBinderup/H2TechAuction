using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using H2TechAuction.Converters;
using H2TechAuction.Models.AuctionModels;
using ReactiveUI;

namespace H2TechAuction.ViewModels;

public class BuyerOfAuctionViewModel : ViewModelBase
{
    private string? _CurrentBid;
    private string? _CarName;
    private Bitmap? _imagePath;
    private bool _determinePlaceBTNVisibility;
    private bool _determineAcceptBTNVisibility;
    private string? _auctionInfoToString;

    public string? AuctionInfoToString
    {
        get => _auctionInfoToString;
        set => this.RaiseAndSetIfChanged(ref _auctionInfoToString, value);
    }
    public bool DeterminePlaceBTNVisibility
    {
        get => _determinePlaceBTNVisibility;
        set => this.RaiseAndSetIfChanged(ref _determinePlaceBTNVisibility, value);
    }
    public bool DetermineAcceptBTNVisibility
    {
        get => _determineAcceptBTNVisibility;
        set => this.RaiseAndSetIfChanged(ref _determineAcceptBTNVisibility, value);
    }
    public string? CurrentBid
    {
        get => _CurrentBid;
        set => this.RaiseAndSetIfChanged(ref _CurrentBid, value);
    }
    public string? CarName
    {
        get => _CarName;
        set => this.RaiseAndSetIfChanged(ref _CarName, value);
    }
    public Bitmap? ImagePath
    {
        get => _imagePath;
        set => this.RaiseAndSetIfChanged(ref _imagePath, value);
    }
    public BuyerOfAuctionViewModel()
    {
        CarName = "Buyer Info!";
        CurrentBid = $"Current Bid: NaN";
        AuctionInfoToString = "[Description]";
        ImagePath = ImageHelper.LoadFromResource(new System.Uri("avares://H2TechAuction/Images/VehicleNotAvailable.jpg"));
    }
    public BuyerOfAuctionViewModel(AuctionItemModel model, bool isYourAuction)
    {
        DeterminePlaceBTNVisibility = true;
        DetermineAcceptBTNVisibility = false;
        if (isYourAuction)
        {
            DeterminePlaceBTNVisibility = false;
            DetermineAcceptBTNVisibility = true;
        }
        AuctionInfoToString = $"Fitting description";
        CarName = model.Name;
        CurrentBid = $"Current Bid: {model.Bid}";
        ImagePath = ImageHelper.LoadFromResource(new System.Uri("avares://H2TechAuction/Images/VehicleNotAvailable.jpg"));
    }
    
}