using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GithubIssues.Models;
using GithubIssues.Services;

namespace GithubIssues.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public bool HasErrorMessage => !string.IsNullOrEmpty(ErrorMessage);
    
    private readonly IGitHubService _gitHubService;

    [ObservableProperty]
    private string _owner = string.Empty;

    [ObservableProperty]
    private string _repository = string.Empty;

    [ObservableProperty]
    private ObservableCollection<Issue> _issues = new();

    [ObservableProperty]
    private bool _isLoading;

    [ObservableProperty]
    private string _errorMessage = string.Empty;

    public MainWindowViewModel(IGitHubService gitHubService)
    {
        _gitHubService = gitHubService;
    }

    [RelayCommand]
    public async Task LoadIssuesAsync()
    {
        if (string.IsNullOrWhiteSpace(Owner) || string.IsNullOrWhiteSpace(Repository))
        {
            ErrorMessage = "Bitte gib Owner und Repository an.";
            return;
        }

        IsLoading = true;
        ErrorMessage = string.Empty;

        try
        {
            var issues = await _gitHubService.GetIssuesAsync(Owner, Repository);
            Console.WriteLine($"Issues geladen: {issues.Count()}");
        
            Issues.Clear();
            foreach (var issue in issues)
            {
                Issues.Add(issue);
                Console.WriteLine($"Issue hinzugefügt: {issue.Title}");
            }
        }
        catch (System.Exception ex)
        {
            ErrorMessage = $"Fehler beim Laden der Issues: {ex.Message}";
        }
        finally
        {
            IsLoading = false;
        }
    }
}