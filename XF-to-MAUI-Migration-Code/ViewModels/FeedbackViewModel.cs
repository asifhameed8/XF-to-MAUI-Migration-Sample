using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using XFtoMAUIApp.Models;
using XFtoMAUIApp.Services;

namespace XFtoMAUIApp.ViewModels
{
    public partial class FeedbackViewModel : ObservableObject
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbackViewModel(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
            FeedbackList = new ObservableCollection<ClientFeedback>();
        }

        [ObservableProperty]
        private ObservableCollection<ClientFeedback> feedbackList;

        [ObservableProperty]
        private string providerName;

        [ObservableProperty]
        private string clientName;

        [ObservableProperty]
        private int rating;

        [ObservableProperty]
        private string comments;

        [ObservableProperty]
        private string appointmentIdText;

        [ObservableProperty]
        private bool isSubmitting;

        [ObservableProperty]
        private bool isLoading;

        [ObservableProperty]
        private string errorMessage;

        [RelayCommand]
        public async Task LoadFeedbackAsync()
        {
            if (string.IsNullOrWhiteSpace(ProviderName))
            {
                ErrorMessage = "Provider name cannot be empty.";
                return;
            }

            IsLoading = true;
            ErrorMessage = string.Empty;

            var results = await _feedbackService.GetFeedbackByProviderAsync(ProviderName);
            FeedbackList.Clear();
            foreach (var item in results)
                FeedbackList.Add(item);

            IsLoading = false;
        }

        [RelayCommand]
        public async Task SubmitFeedbackAsync()
        {
            ErrorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(ClientName) ||
                string.IsNullOrWhiteSpace(ProviderName) ||
                string.IsNullOrWhiteSpace(Comments) ||
                !int.TryParse(AppointmentIdText, out var appointmentId) ||
                Rating < 1 || Rating > 5)
            {
                ErrorMessage = "Please fill in all fields correctly.";
                return;
            }

            IsSubmitting = true;

            var feedback = new ClientFeedback
            {
                AppointmentId = appointmentId,
                ClientName = ClientName,
                ProviderName = ProviderName,
                Rating = Rating,
                Comments = Comments,
                DateSubmitted = DateTime.Now.ToString("yyyy-MM-dd")
            };

            var success = await _feedbackService.SubmitFeedbackAsync(feedback);

            if (success)
            {
                FeedbackList.Add(feedback);
                ClientName = string.Empty;
                Comments = string.Empty;
                Rating = 0;
                AppointmentIdText = string.Empty;
            }
            else
            {
                ErrorMessage = "Submission failed. Please try again.";
            }

            IsSubmitting = false;
        }
    }
}
