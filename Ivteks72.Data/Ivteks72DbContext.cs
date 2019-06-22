namespace Ivteks72.Data
{
    using Ivteks72.Domain;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

    public class Ivteks72DbContext : IdentityDbContext<User, Role, string>
    {
    }
}
