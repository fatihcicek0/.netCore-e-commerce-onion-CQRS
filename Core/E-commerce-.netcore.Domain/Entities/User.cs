using Microsoft.AspNetCore.Identity;


namespace E_commerce_.netcore.Domain.Entities
{
    public class User:IdentityUser<Guid>
    {
        public string FullName { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
    }
}
