namespace App.HRIS.Entities.Models
{
    public class UserSession
    {
        public string UserId { get; set; } = null!;

        public string SessionId { get; set; } = null!;

        public string? DeviceId { get; set; }

        public DateTime? LastActivity { get; set; }

        public bool? IsActive { get; set; }
    }
}
