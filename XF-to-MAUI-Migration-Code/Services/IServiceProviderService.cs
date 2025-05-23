using XFtoMAUIApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace XFtoMAUIApp.Services
{
    public interface IServiceProviderService
    {
        Task<List<ServiceProvider>> GetAllProvidersAsync();
        Task<ServiceProvider> GetProviderByIdAsync(int id);
        Task<List<ServiceProvider>> SearchProvidersBySpecialtyAsync(string specialty);
    }
}
