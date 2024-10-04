using H2TechAuction.Models.DatabaseRepositories;
using H2TechAuction.Models.UserModels;
using Microsoft.IdentityModel.Tokens;
using Microsoft.SqlServer.Server;
using ReactiveUI;

namespace H2TechAuction.ViewModels;

public class RegisterScreenViewModel : ViewModelBase
{
    private string? _Username;
    private string? _Password;
    private string? _PasswordRepeat;
    private string? _ErrorMessage;
    private bool _IsErrorMessageVisible;
    private string? _IdentificationValue;
    private string? _IdentificationType;
    private bool _IsCorporateSelected;
    private bool _IsPrivateSelected;
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
    public string? ErrorMessage
    {
        get => _ErrorMessage;
        set => this.RaiseAndSetIfChanged(ref _ErrorMessage, value, nameof(ErrorMessage));
    }
    public bool IsErrorMessageVisible
    {
        get => _IsErrorMessageVisible;
        set => this.RaiseAndSetIfChanged(ref _IsErrorMessageVisible, value, nameof(IsErrorMessageVisible));
    }
    public string? IdentificationValue
    {
        get => _IdentificationValue;
        set => this.RaiseAndSetIfChanged(ref _IdentificationValue, value, nameof(IdentificationValue));

    }
    public string? IdentificationType
    {
        get => _IdentificationType;
        set => this.RaiseAndSetIfChanged(ref _IdentificationType, value, nameof(IdentificationType));
    }
    public bool IsCorporateSelected
    {
        get => _IsCorporateSelected;
        set
        {
            this.RaiseAndSetIfChanged(ref _IsCorporateSelected, value);
            if (value)
            {
                IdentificationType = "Enter CVR-Number"; 
            }
        }
    }

    public bool IsPrivateSelected
    {
        get => _IsPrivateSelected;
        set
        {
            this.RaiseAndSetIfChanged(ref _IsPrivateSelected, value);
            if (value)
            {
                IdentificationType = "Enter CPR-Number";
            }
        }
    }
    public void Cancel()
    {
        MainWindowViewModel.Instance?.SetViewModel(new LoginScreenViewModel());
    }
    public void CreateAccount()
    {
        if(string.IsNullOrEmpty(_Username) || string.IsNullOrEmpty(_Password) ||
            string.IsNullOrEmpty(_PasswordRepeat) || 
            _Password != _PasswordRepeat || string.IsNullOrEmpty(IdentificationValue))
        {
            if (string.IsNullOrEmpty(_Username))
            {
                ErrorMessage = "Username cannot be empty.";
            }
            else if (string.IsNullOrEmpty(_Password))
            {
                ErrorMessage = "Password cannot be empty.";
            }
            else if (_Password != _PasswordRepeat)
            {
                ErrorMessage = "Passwords do not match.";
            }
            else if (string.IsNullOrEmpty(IdentificationValue))
            {
                if (IsCorporateSelected)
                    ErrorMessage = "Please enter CVR-number to register...";
                else if (IsPrivateSelected)
                    ErrorMessage = "Please enter CPR-number to register...";
            }
            IsErrorMessageVisible = true;
        }
        else
        {
            IsErrorMessageVisible = false;
            ErrorMessage = null;

            UserRepository repo = new();
            if(IsCorporateSelected)
            {
                //DBTODO
                repo.Create(new CorporateUser(0, IdentificationValue));
            }
            else if(IsPrivateSelected)
            {
                //DBTODO
                repo.Create(new PrivateUser(IdentificationValue));
            }

            MainWindowViewModel.Instance?.SetViewModel(new LoginScreenViewModel());
        }
    }
}
