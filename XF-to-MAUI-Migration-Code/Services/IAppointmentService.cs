using XFtoMAUIApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XFtoMAUIApp.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly List<Appointment> _appointments;

        public AppointmentService()
        {
            _appointments = new List<Appointment>
            {
                new Appointment { Id = 1, Title = "Consultation", Date = "2025-06-01", Time = "10:00 AM", Location = "Room 101", Notes = "Initial consult", IsConfirmed = false, ProviderName = "Dr. Smith", ClientName = "John Doe", ContactEmail = "john@example.com" },
                new Appointment { Id = 2, Title = "Follow-up", Date = "2025-06-05", Time = "2:00 PM", Location = "Room 102", Notes = "Review results", IsConfirmed = true, ProviderName = "Dr. Smith", ClientName = "Jane Doe", ContactEmail = "jane@example.com" }
            };
        }

        public async Task<List<Appointment>> GetAppointmentsAsync()
        {
            await Task.Delay(200);
            return _appointments;
        }

        public async Task<Appointment> GetAppointmentByIdAsync(int id)
        {
            await Task.Delay(100);
            return _appointments.FirstOrDefault(a => a.Id == id);
        }

        public async Task<List<Appointment>> GetAppointmentsByProviderAsync(string providerName)
        {
            await Task.Delay(150);
            return _appointments.Where(a => a.ProviderName == providerName).ToList();
        }

        public async Task<bool> ConfirmAppointmentAsync(int id)
        {
            await Task.Delay(100);
            var appointment = _appointments.FirstOrDefault(a => a.Id == id);
            if (appointment != null)
            {
                appointment.IsConfirmed = true;
                return true;
            }
            return false;
        }

        public async Task<bool> CancelAppointmentAsync(int id)
        {
            await Task.Delay(100);
            var appointment = _appointments.FirstOrDefault(a => a.Id == id);
            if (appointment != null)
            {
                _appointments.Remove(appointment);
                return true;
            }
            return false;
        }
    }
}
