using TripPlaning.Core.Model;

namespace TripPlaning.API.DTO
{
    public class UserPostModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRole Role { get; set; }
    }
}
