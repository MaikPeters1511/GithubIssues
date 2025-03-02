using System;
using Avalonia.Controls;
using GithubIssues.Services;
using GithubIssues.ViewModels;

namespace GithubIssues.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    
        // Service und ViewModel direkt im Konstruktor erstellen
        var gitHubService = new GitHubService("GithubIssues");
        DataContext = new MainWindowViewModel(gitHubService);
    
        Console.WriteLine($"DataContext ist: {DataContext?.GetType().Name ?? "null"}");

        // LoadIssuesCommand nach AttachedToVisualTree ausführen
        this.AttachedToVisualTree += (s, e) =>
        {
            Console.WriteLine("Fenster geladen");
            var vm = DataContext as MainWindowViewModel;
            vm?.LoadIssuesCommand.Execute(null);
            Console.WriteLine($"Issues im ViewModel: {(vm?.Issues?.Count ?? 0)}");
        };
    }
}