using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using H2TechAuction.ViewModels;

namespace H2TechAuction.Views;

public partial class SetForSaleView : UserControl
{
    public SetForSaleView()
    {
        InitializeComponent();
        DataContext = new SetForSaleViewModel();
    }
    private void BackButton_click(object sender, RoutedEventArgs e) =>
        MainWindowViewModel.Instance?.SetViewModel(new HomeScreenViewModel());
}