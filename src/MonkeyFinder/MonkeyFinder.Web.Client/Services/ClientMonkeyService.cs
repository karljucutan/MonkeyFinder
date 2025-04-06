﻿using System.Net.Http.Json;
using MonkeyFinder.Shared.Models;
using MonkeyFinder.Shared.Services.Abstractions;

namespace MonkeyFinder.Web.Client.Services;

public class ClientMonkeyService(HttpClient httpClient) : IMonkeyService
{
    public Task<Monkey> AddMonkeyAsync(Monkey monkey)
    {
        // TODO: KLJ - implement the Backend Call.
        throw new NotImplementedException();
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
