using Microsoft.AspNetCore.Identity;

namespace ETicaretAPI.Domain.Entities.Identities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string FullName { get; set; }
    }
}
