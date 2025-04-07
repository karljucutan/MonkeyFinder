namespace MonkeyFinder.Shared.Services.Abstractions;

public interface IMonkeyService
{
    Task<Monkey> AddMonkeyAsync(Monkey monkey);
    Task<Monkey> FindMonkeyByNameAsync(string name);
    Task<List<Monkey>> GetMonkeysAsync();
}
