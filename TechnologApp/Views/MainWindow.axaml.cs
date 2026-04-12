using Avalonia.Controls;
using TechnologApp.ViewModels;

namespace TechnologApp.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }
}