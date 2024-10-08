﻿using H2TechAuction.Models.DatabaseRepositories;
using H2TechAuction.Models.UserModels;
using H2TechAuction.Models.UserModels.Generators;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace H2TechAuction.ViewModels;


public class LoginScreenViewModel : ViewModelBase
{
    public static User? User { get; set; }

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
        UserRepository repo = new();
        if(string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
        {
            Debug.WriteLine("error");
        }
        else
        {
            var validateUser = repo.ValidateUser(Username, PasswordHash.HashPassword(Password));

            User = repo.Read(Username, PasswordHash.HashPassword(Password));

            if (validateUser)
            {
                MainWindowViewModel.Instance?.SetViewModel(new HomeScreenViewModel());
            }
            else
            {
                Debug.WriteLine("Error");
            }
        }
        
    }
}
