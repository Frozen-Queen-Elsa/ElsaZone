using Microsoft.AspNetCore.Identity;

namespace ElsaZone.Data.Entities;

public class AppRole: IdentityRole<Guid>
{
    public string Description { get; set; }
}