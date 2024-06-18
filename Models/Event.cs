namespace Coding_Challenge.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime? EventData { get; set; }

        public string Location { get; set; } = string.Empty;

        public int MaxAttendees { get; set; }

        public double Fees { get; set; }

    }
}
