using XFtoMAUIApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace XFtoMAUIApp.Services
{
    public interface IAppointmentService
    {
        Task<List<Appointment>> GetAppointmentsAsync();
    }
}