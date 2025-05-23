namespace XFtoMAUIApp.Models
{
    public class ServiceProvider
    {
        public int ProviderId { get; set; }
        public string Name { get; set; }
        public string Specialty { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string OfficeLocation { get; set; }
        public string LicenseNumber { get; set; }
        public double Rating { get; set; }
        public bool IsAvailable { get; set; }
        public string Notes { get; set; }
    }
}
