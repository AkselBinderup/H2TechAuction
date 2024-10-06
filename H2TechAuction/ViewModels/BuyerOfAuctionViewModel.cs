using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using H2TechAuction.Converters;
using H2TechAuction.Models.AuctionModels;
using H2TechAuction.Models.DatabaseRepositories;
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
    private decimal _bidAmount;
    private bool _baIsVisible;
    private int _AuctionId;
    private bool _DetermineConfirmVisibility;

    public bool DetermineConfirmVisibility
    {
        get => _DetermineConfirmVisibility;
        set => this.RaiseAndSetIfChanged(ref  _DetermineConfirmVisibility, value);
    }

    public int AuctionId
    {
        get => _AuctionId;
        set => this.RaiseAndSetIfChanged(ref _AuctionId, value);
    }
    public bool BAIsVisible
    {
        get => _baIsVisible;
        set => this.RaiseAndSetIfChanged(ref _baIsVisible, value);
    }
    public decimal BidAmount
    {
        get => _bidAmount;
        set => this.RaiseAndSetIfChanged(ref _bidAmount, value);
    }
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
    public BuyerOfAuctionViewModel(VisualAuction model, bool isYourAuction)
    {
        AuctionRepository repository = new();
        var auctions = repository.Read(model.VehicleId.ToString(), "");
        
        DeterminePlaceBTNVisibility = true;
        DetermineAcceptBTNVisibility = false;
        if (isYourAuction)
        {
            DeterminePlaceBTNVisibility = false;
            DetermineAcceptBTNVisibility = true;
        }
        AuctionInfoToString = $"Fitting description";
        CarName = model.Name;
        if(auctions.CurrentBid == 0)
        {
            CurrentBid = $"Asking price: {auctions.AskingPrice}";
        }
        CurrentBid = $"Current Bid: {auctions.CurrentBid}";
        AuctionId = auctions.AuctionId;
        ImagePath = ImageHelper.LoadFromResource(new System.Uri("avares://H2TechAuction/Images/VehicleNotAvailable.jpg"));
    }
   
}