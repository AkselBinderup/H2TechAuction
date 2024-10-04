using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2TechAuction.ViewModels;
public class ProfileViewModel : ViewModelBase
{
    private string? _name;
    private string? _yourAuctions;
    private string? _auctionsWon;

    public string? Name
    {
        get => _name;
        set => this.RaiseAndSetIfChanged(ref _name, value);
    }
    public string? YourAuctions
    {
        get => _yourAuctions;
        set => this.RaiseAndSetIfChanged(ref _yourAuctions, value);
    }
    public string? AuctionsWon
    {
        get => _auctionsWon;
        set => this.RaiseAndSetIfChanged(ref _auctionsWon, value);
    }
    public ProfileViewModel()
    {  
        Name = LoginScreenViewModel.User.Username;
    }  
}
