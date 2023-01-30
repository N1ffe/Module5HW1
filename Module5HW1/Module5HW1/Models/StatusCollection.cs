namespace Module5HW1.Models
{
    public class StatusCollection<T> : Status
    {
        public IReadOnlyCollection<T>? Data { get; init; }
    }
}
