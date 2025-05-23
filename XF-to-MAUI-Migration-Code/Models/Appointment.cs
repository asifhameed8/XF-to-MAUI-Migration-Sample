namespace XFtoMAUIApp.Models
{
    public class Appointment
    {
         public int Id { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Location { get; set; }
        public string Notes { get; set; }
        public bool IsConfirmed { get; set; }
        public string ProviderName { get; set; }
        public string ClientName { get; set; }
        public string ContactEmail { get; set; }
    }
}
