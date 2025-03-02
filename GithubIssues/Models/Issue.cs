using System;

namespace GithubIssues.Models;

public class Issue
{
    public int Number { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public DateTimeOffset CreatedAt { get; set; }
    public string Url { get; set; } = string.Empty;
    public string UserLogin { get; set; } = string.Empty;
}