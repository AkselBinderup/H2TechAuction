using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using H2TechAuction.ViewModels;

namespace H2TechAuction.Views;

public partial class ProfileView : UserControl
{
    public ProfileView()
    {
        InitializeComponent();
        DataContext = new ProfileViewModel();
    }
    private void BackButton_click(object sender, RoutedEventArgs e)
    {
        MainWindowViewModel.Instance?.SetViewModel(new HomeScreenViewModel());
    }
}