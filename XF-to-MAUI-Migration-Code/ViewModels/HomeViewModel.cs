using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using XFtoMAUIApp.Models;
using XFtoMAUIApp.Services;

namespace XFtoMAUIApp.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        private readonly IAppointmentService _appointmentService;

        public HomeViewModel(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
            Appointments = new ObservableCollection<Appointment>();
        }

        [ObservableProperty]
        private ObservableCollection<Appointment> appointments;

        [RelayCommand]
        private async Task LoadAppointmentsAsync()
        {
            var items = await _appointmentService.GetAppointmentsAsync();
            Appointments.Clear();
            foreach (var item in items)
                Appointments.Add(item);
        }
    }
}