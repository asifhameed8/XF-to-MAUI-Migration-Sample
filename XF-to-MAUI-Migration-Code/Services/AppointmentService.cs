using XFtoMAUIApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace XFtoMAUIApp.Services
{
    public class AppointmentService : IAppointmentService
    {
        public async Task<List<Appointment>> GetAppointmentsAsync()
        {
            await Task.Delay(500); // Simulate API delay
            return new List<Appointment>
            {
                new Appointment { Title = "Consultation", Date = "2025-06-01" },
                new Appointment { Title = "Follow-up", Date = "2025-06-05" }
            };
        }
    }
}