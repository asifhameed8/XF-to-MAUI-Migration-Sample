using XFtoMAUIApp.Models;
using System.Threading.Tasks;

namespace XFtoMAUIApp.Services
{
    public interface IUserProfileService
    {
        Task<UserProfile> GetUserProfileAsync(int userId);
    }
}