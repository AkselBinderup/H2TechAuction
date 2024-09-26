using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H2TechAuction.ViewModels;

public class LoginScreenViewModel : ViewModelBase
{
    private string? _userName;
    private string? _password;

    public string? Username
    {
        get => _userName;
        set => this.RaiseAndSetIfChanged(ref _userName, value, nameof(Username));
    }

    public string? Password
    {
        get => _password;
        set => this.RaiseAndSetIfChanged(ref _password, value, nameof(Password));
    }


}
