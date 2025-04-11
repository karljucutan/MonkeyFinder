using MonkeyFinder.Shared.Services.Abstractions;
using System.Net.Http.Json;

namespace MonkeyFinder.Shared.Services;

// This should be on the Web project and the MAUI apps will get monkeys using the Web API.
public class MonkeyService : IMonkeyService
{
    private readonly HttpClient _httpClient;
    private List<Monkey> _monkeysList = [];

    public MonkeyService()
    {
        _httpClient = new HttpClient();
    }

    public async Task<List<Monkey>> GetMonkeysAsync()
    {
        if (_monkeysList.Count > 0)
            return _monkeysList;

        var response = await _httpClient.GetAsync("https://montemagno.com/monkeys.json");
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadFromJsonAsync(MonkeyContext.Default.ListMonkey);

            if (result is not null)
                _monkeysList = result;
        }

        return _monkeysList;
    }

    public async Task<Monkey> AddMonkeyAsync(Monkey monkey)
    {
        _monkeysList.Add(monkey);

        return await Task.FromResult(monkey);
    }

    public async Task<Monkey> FindMonkeyByNameAsync(string name)
    {
        var monkey = _monkeysList.FirstOrDefault(x => string.Equals(x.Name, name, StringComparison.OrdinalIgnoreCase))
            ?? throw new Exception("Monkey not found");

        return await Task.FromResult(monkey);
    }
}
