namespace Module5HW1.Models
{
    public class Employee : Status
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
        public string CreatedAt { get; set; }
        public string? UpdatedAt { get; set; }
    }
}
