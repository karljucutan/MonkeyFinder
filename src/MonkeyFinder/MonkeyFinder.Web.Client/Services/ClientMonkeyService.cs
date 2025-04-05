using System.Net.Http.Json;
using MonkeyFinder.Shared.Models;
using MonkeyFinder.Shared.Services.Abstractions;

namespace MonkeyFinder.Web.Client.Services;

public class ClientMonkeyService(HttpClient httpClient) : IMonkeyService
{
    public async Task<List<Monkey>> GetMonkeysAsync()
    {
        HttpResponseMessage response = await httpClient.GetAsync("api/monkeys");
        if (response.IsSuccessStatusCode)
        {
            List<Monkey>? result = await response.Content.ReadFromJsonAsync(MonkeyContext.Default.ListMonkey);
            return result ?? [];
        }

        return [];
    }
}
