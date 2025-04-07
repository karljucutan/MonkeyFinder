using System.Net.Http.Json;
using MonkeyFinder.Shared.Models;
using MonkeyFinder.Shared.Services.Abstractions;

namespace MonkeyFinder.Web.Client.Services;

public class ClientMonkeyService(HttpClient httpClient) : IMonkeyService
{
    public async Task<Monkey> AddMonkeyAsync(Monkey monkey)
    {
        var response = await httpClient.PostAsJsonAsync("api/monkeys", monkey);
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync(MonkeyContext.Default.Monkey);
            return result ?? new Monkey();
        }

        throw new Exception("Failed to add monkey");
    }

    public async Task<List<Monkey>> GetMonkeysAsync()
    {
        var response = await httpClient.GetAsync("api/monkeys");
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync(MonkeyContext.Default.ListMonkey);
            return result ?? [];
        }

        return [];
    }
}
