namespace MonkeyFinder.Shared.States;

public class MonkeyRatingState
{
    public Dictionary<Monkey, int> MonkeyRatings { get; } = [];
    public event EventHandler? OnRatingChanged;

    // Property to store the current monkey for rating.
    public Monkey? SelectedMonkey { get; set; }

    public void AddOrUpdateRating(Monkey monkey, int rating)
    {
        if (!MonkeyRatings.TryAdd(monkey, rating))
        {
            MonkeyRatings[monkey] = rating;
        }

        OnRatingChanged?.Invoke(this, EventArgs.Empty);
    }

    public int GetRating(Monkey monkey)
    {
        if (monkey is not null && MonkeyRatings.TryGetValue(monkey, out var rating))
        {
            return rating;
        }

        return 0;
    }
}
