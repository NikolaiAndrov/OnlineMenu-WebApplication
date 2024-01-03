namespace OnlineMenu.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using OnlineMenu.Data.Models;

    public class OnlineMenuDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public OnlineMenuDbContext(DbContextOptions<OnlineMenuDbContext> options)
            : base(options)
        {
        }
    }
}
