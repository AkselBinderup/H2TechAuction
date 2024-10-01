using Microsoft.IdentityModel.Tokens;
using ReactiveUI;

namespace H2TechAuction.ViewModels;

public class RegisterScreenViewModel : ViewModelBase
{
    private string? _Username;
    private string? _Password;
    private string? _PasswordRepeat;
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
    public string? PasswordRepeat
    {
        get => _PasswordRepeat;
        set => this.RaiseAndSetIfChanged(ref _PasswordRepeat, value, nameof(PasswordRepeat));
    }
    public void Cancel()
    {
        MainWindowViewModel.Instance.SetViewModel(new LoginScreenViewModel());
    }
    public void CreateAccount()
    {
        if(string.IsNullOrEmpty(_Username) || string.IsNullOrEmpty(_Password) ||
            string.IsNullOrEmpty(_PasswordRepeat) || 
            _Password != _PasswordRepeat)
        {
            //error
        }
        else
        {
            MainWindowViewModel.Instance.SetViewModel(new LoginScreenViewModel());
        }
    }
}
