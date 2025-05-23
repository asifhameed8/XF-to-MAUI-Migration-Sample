using CommunityToolkit.Mvvm.ComponentModel;
using System.Threading.Tasks;
using XFtoMAUIApp.Models;
using XFtoMAUIApp.Services;

namespace XFtoMAUIApp.ViewModels
{
    public partial class UserProfileViewModel : ObservableObject
    {
        private readonly IUserProfileService _profileService;

        public UserProfileViewModel(IUserProfileService profileService)
        {
            _profileService = profileService;
        }

        [ObservableProperty]
        private UserProfile profile;

        public async Task LoadProfileAsync(int userId)
        {
            Profile = await _profileService.GetUserProfileAsync(userId);
        }
    }
}