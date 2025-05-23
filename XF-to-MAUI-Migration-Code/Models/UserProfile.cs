namespace XFtoMAUIApp.Models
{
    public class UserProfile
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
        public string AvatarUrl { get; set; }
        public bool IsActive { get; set; }
        public string Notes { get; set; }
    }
}