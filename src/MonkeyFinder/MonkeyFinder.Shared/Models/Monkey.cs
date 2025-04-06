namespace MonkeyFinder.Shared.Models;

public class Monkey
{
    public string Name { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string Details { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public int Population { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}



/// <summary>
/// This source-generated context enables high-performance JSON serialization and deserialization
/// 
/// Instead of relying on runtime reflection (which is slower and more memory-intensive),
/// it uses compile-time metadata generation (via source generators) for Ahead-of-Time (AOT) support.
/// This improves performance, reduces allocations, and is especially useful in trimming-friendly or AOT-compiled applications
/// such as those using NativeAOT or Blazor WebAssembly.
///
/// Use this context when calling JsonSerializer methods:
/// e.g., JsonSerializer.Serialize(value, MonkeyContext.Default.Monkey); 
/// </summary>
/// 
[JsonSourceGenerationOptions(PropertyNameCaseInsensitive = true)]
[JsonSerializable(typeof(List<Monkey>))]
[JsonSerializable(typeof(Monkey))]
public sealed partial class MonkeyContext : JsonSerializerContext
{
}
