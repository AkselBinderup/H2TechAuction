using ReactiveUI;

namespace H2TechAuction.ViewModels;

public class RegisterScreenViewModel : ViewModelBase
{
    private string? _Username;
    private string? _Password;
    public string? Username
    {
        get => _Username;
        set => this.RaiseAndSetIfChanged(ref _Username, value, nameof(Username));
    }
    public string? Password
    {
        get => _Password;
        set => this.RaiseAndSetIfChanged(ref _Password, value, nameof(Password));
    }
}
