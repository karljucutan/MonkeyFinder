namespace MonkeyFinder.Shared.Services.Abstractions;

public interface IMonkeyService
{
    Task<List<Monkey>> GetMonkeysAsync();
}