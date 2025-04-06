namespace MonkeyFinder.Shared.Services.Abstractions;

public interface IMonkeyService
{
    Task<Monkey> AddMonkeyAsync(Monkey monkey);
    Task<List<Monkey>> GetMonkeysAsync();
}
