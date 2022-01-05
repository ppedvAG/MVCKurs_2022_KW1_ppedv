namespace LabGuestBookApp.Models
{
    public class GuestBookEntry
    {
        public int Id { get; set; }
        public string Message { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
    }
}
