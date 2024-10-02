using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace H2TechAuction.ViewModels;

public class LoginScreenViewModel : ViewModelBase
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

    public LoginScreenViewModel()
    {
    }

    public void CreateUser()
    {
        MainWindowViewModel.Instance?.SetViewModel(new RegisterScreenViewModel());
    }

    public void Login()
    {
        if(Username == "user" && Password == "Pass")
        {
            MainWindowViewModel.Instance?.SetViewModel(new HomeScreenViewModel());
        }
    }
}
