namespace Coding_Challenge.Models.DTO
{
    public class EventUpdateDto
    {
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public DateTime? EventData { get; set; }

        public string Location { get; set; } = string.Empty;

        public int MaxAttendees { get; set; }

        public double Fees { get; set; }
    }
}
