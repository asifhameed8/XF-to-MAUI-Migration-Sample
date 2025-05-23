using XFtoMAUIApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XFtoMAUIApp.Services
{
    public class ServiceProviderService : IServiceProviderService
    {
        private readonly List<ServiceProvider> _providers;

        public ServiceProviderService()
        {
            _providers = new List<ServiceProvider>
            {
                new ServiceProvider { ProviderId = 1, Name = "Dr. Smith", Specialty = "General Medicine", Phone = "111-222-3333", Email = "smith@example.com", OfficeLocation = "Building A", LicenseNumber = "LIC123", Rating = 4.5, IsAvailable = true, Notes = "Experienced" },
                new ServiceProvider { ProviderId = 2, Name = "Dr. Taylor", Specialty = "Dermatology", Phone = "444-555-6666", Email = "taylor@example.com", OfficeLocation = "Building B", LicenseNumber = "LIC456", Rating = 4.8, IsAvailable = false, Notes = "Specialist in skin disorders" }
            };
        }

        public async Task<List<ServiceProvider>> GetAllProvidersAsync()
        {
            await Task.Delay(200);
            return _providers;
        }

        public async Task<ServiceProvider> GetProviderByIdAsync(int id)
        {
            await Task.Delay(100);
            return _providers.FirstOrDefault(p => p.ProviderId == id);
        }

        public async Task<List<ServiceProvider>> SearchProvidersBySpecialtyAsync(string specialty)
        {
            await Task.Delay(150);
            return _providers.Where(p => p.Specialty.ToLower().Contains(specialty.ToLower())).ToList();
        }
    }
}
