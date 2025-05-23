using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using XFtoMAUIApp.Models;
using XFtoMAUIApp.Services;

namespace XFtoMAUIApp.ViewModels
{
    public partial class AppointmentViewModel : ObservableObject
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentViewModel(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
            Appointments = new ObservableCollection<Appointment>();
            FilteredAppointments = new ObservableCollection<Appointment>();
        }

        [ObservableProperty]
        private ObservableCollection<Appointment> appointments;

        [ObservableProperty]
        private ObservableCollection<Appointment> filteredAppointments;

        [ObservableProperty]
        private Appointment selectedAppointment;

        [ObservableProperty]
        private string providerFilter;

        [RelayCommand]
        public async Task LoadAppointmentsAsync()
        {
            var result = await _appointmentService.GetAppointmentsAsync();
            Appointments.Clear();
            foreach (var appt in result)
                Appointments.Add(appt);

            FilterAppointments();
        }

        [RelayCommand]
        private void FilterAppointments()
        {
            FilteredAppointments.Clear();
            var filtered = string.IsNullOrWhiteSpace(ProviderFilter)
                ? Appointments
                : new ObservableCollection<Appointment>(
                    Appointments.Where(a => a.ProviderName.Contains(ProviderFilter, StringComparison.OrdinalIgnoreCase)));

            foreach (var item in filtered)
                FilteredAppointments.Add(item);
        }

        [RelayCommand]
        public async Task ConfirmSelectedAppointmentAsync()
        {
            if (SelectedAppointment != null)
            {
                var success = await _appointmentService.ConfirmAppointmentAsync(SelectedAppointment.Id);
                if (success)
                    SelectedAppointment.IsConfirmed = true;
            }
        }

        [RelayCommand]
        public async Task CancelSelectedAppointmentAsync()
        {
            if (SelectedAppointment != null)
            {
                var success = await _appointmentService.CancelAppointmentAsync(SelectedAppointment.Id);
                if (success)
                    Appointments.Remove(SelectedAppointment);
            }
        }

        [RelayCommand]
        public void SelectAppointment(Appointment appointment)
        {
            SelectedAppointment = appointment;
        }
    }
}
