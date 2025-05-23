using XFtoMAUIApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace XFtoMAUIApp.Services
{
    public interface IFeedbackService
    {
        Task<List<ClientFeedback>> GetFeedbackByProviderAsync(string providerName);
        Task<bool> SubmitFeedbackAsync(ClientFeedback feedback);
    }
}
