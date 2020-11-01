using Microsoft.AspNetCore.Identity;

namespace WebApp.DAL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public byte[] AvatarImage { get; set; }
    }
}
