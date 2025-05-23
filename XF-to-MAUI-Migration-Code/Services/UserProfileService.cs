using XFtoMAUIApp.Models;
using System.Threading.Tasks;

namespace XFtoMAUIApp.Services
{
    public class UserProfileService : IUserProfileService
    {
        public async Task<UserProfile> GetUserProfileAsync(int userId)
        {
            await Task.Delay(300); // Simulated delay
            return new UserProfile
            {
                UserId = userId,
                FirstName = "Asif",
                LastName = "Developer",
                Email = "asif@example.com",
                PhoneNumber = "123-456-7890",
                Address = "123 Dev Street",
                Role = "Admin",
                AvatarUrl = "https://example.com/avatar.png",
                IsActive = true,
                Notes = "Experienced .NET MAUI Developer"
            };
        }
    }
}