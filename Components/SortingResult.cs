public class SortingResult
{
    public string? Algorithm { get; set; }
    public int Swaps { get; set; }
    public TimeSpan ElapsedTime { get; set; }
    public int RandomCount { get; internal set; }
}