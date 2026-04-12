using System.Collections.Generic;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TechnologApp.Views;

namespace TechnologApp.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty] private object? _currentView;
    [ObservableProperty] private string _userName = "Технолог";
    [ObservableProperty] private string _userRole = "Технологический отдел";

    private readonly Dictionary<string, UserControl> _views;

    public MainWindowViewModel()
    {
        _views = new()
        {
            //["Dashboard"] = new DashboardView(),
            ["Products"] = new ProductsView(),
            // ["Recipes"] = new RecipesView(),
            // ["TechMaps"] = new TechMapsView(),
            // ["Batches"] = new ProductionBatchesView(),
            // ["Reports"] = new ReportsView()
        };
        CurrentView = _views["Products"];
    }

    // [RelayCommand] private void Navigate(string page) => CurrentView = _views.GetValueOrDefault(page, _views["Dashboard"]);
    // [RelayCommand] private void Logout() { TokenStorage.ClearToken(); Environment.Exit(0); }
}