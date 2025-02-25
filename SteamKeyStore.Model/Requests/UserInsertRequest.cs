using SteamKeyStore.Model.Models;

namespace SteamKeyStore.Model.Requests
{
    public class UserInsertRequest
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public UserRole Role { get; set; }
    }
}
