using System.Collections.Generic;
using System.Threading.Tasks;
using GithubIssues.Models;

namespace GithubIssues.Services;

public interface IGitHubService
{
    Task<IEnumerable<Issue>> GetIssuesAsync(string owner, string repository);

}