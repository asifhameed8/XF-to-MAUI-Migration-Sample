using XFtoMAUIApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace XFtoMAUIApp.Services
{
    public interface IAppointmentService
    {
        Task<List<Appointment>> GetAppointmentsAsync();
        Task<Appointment> GetAppointmentByIdAsync(int id);
        Task<List<Appointment>> GetAppointmentsByProviderAsync(string providerName);
        Task<bool> ConfirmAppointmentAsync(int id);
        Task<bool> CancelAppointmentAsync(int id);
    }
}
