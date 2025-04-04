using MonkeyFinder.Shared.Models;
using MonkeyFinder.Shared.Services.Abstractions;

namespace MonkeyFinder.Web.Client.Services;

public class MonkeyService : IMonkeyService
{
    public Task<List<Monkey>> GetMonkeysAsync()
    {
        // TODO: Call the BFF api
        return Task.FromResult(new List<Monkey>());
    }
}
