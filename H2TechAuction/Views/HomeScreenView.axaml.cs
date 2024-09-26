using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using H2TechAuction.ViewModels;

namespace H2TechAuction.Views;

public partial class HomeScreenView : UserControl
{
    public HomeScreenView()
    {
        InitializeComponent();
        DataContext = new HomeScreenViewModel();
    }
}