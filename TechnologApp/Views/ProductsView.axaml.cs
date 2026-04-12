using Avalonia.Controls;
using TechnologApp.ViewModels;

namespace TechnologApp.Views;

public partial class ProductsView : UserControl
{
    public ProductsView()
    {
        InitializeComponent();
        DataContext = new ProductsViewModel();
    }
}
