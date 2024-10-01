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
    public ReactiveCommand<Unit, Unit> LoginCommand { get; }

    public LoginScreenViewModel()
    {
        LoginCommand = ReactiveCommand.Create(() =>
        {
            if (Username == "user" && Password == "password")
            {
                MainWindowViewModel.Instance?.SetViewModel(new HomeScreenViewModel());
            }
            else
            {
                Console.WriteLine("Login failed");
            }
        });
    }

}
