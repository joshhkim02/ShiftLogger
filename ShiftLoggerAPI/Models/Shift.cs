namespace ShiftLoggerAPI.Models
{
    public class Shift
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Date { get; set; } = null!;
        public string HoursWorked { get; set; } = null!;
    }
}
