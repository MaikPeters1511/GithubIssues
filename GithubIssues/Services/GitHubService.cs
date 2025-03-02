using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Octokit;
using Issue = GithubIssues.Models.Issue;

namespace GithubIssues.Services;

public class GitHubService(string productName) : IGitHubService
{
    private readonly GitHubClient _client = new(new ProductHeaderValue(productName));

    public async Task<IEnumerable<Issue>> GetIssuesAsync(string owner, string repository)
    {
        Console.WriteLine($"Rufe Issues für {owner}/{repository} ab...");
        var issues = await _client.Issue.GetAllForRepository(owner, repository);
        Console.WriteLine($"Anzahl der Issues: {issues.Count}");        var result = new List<Issue>();

        foreach (var issue in issues)
        {
            Console.WriteLine($"Issue #{issue.Number}: {issue.Title}");

            result.Add(new Issue
            {
                Number = issue.Number,
                Title = issue.Title,
                Body = issue.Body,
                State = issue.State.StringValue,
                CreatedAt = issue.CreatedAt,
                Url = issue.HtmlUrl,
                UserLogin = issue.User.Login
            });
        }
        return result;
    }
}