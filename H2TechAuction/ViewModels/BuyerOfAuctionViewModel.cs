using ReactiveUI;

namespace H2TechAuction.ViewModels;

public class BuyerOfAuctionViewModel : ViewModelBase
{
    private string? _imagePath;
    public string? ImagePath
    {
        get => _imagePath;
        set => this.RaiseAndSetIfChanged(ref _imagePath, value);
    }
    public BuyerOfAuctionViewModel()
    {
        ImagePath = @"C:\Users\Z6APT\Documents\Programmering\C#\H2TechAuction\H2TechAuction\Images\depositphotos_227724992-stock-illustration-image-available-icon-flat-vector.jpg";
    }
}