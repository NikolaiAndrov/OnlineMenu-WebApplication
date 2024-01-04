namespace OnlineMenu.Data
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using OnlineMenu.Data.Models;
    using System.Reflection;

    public class OnlineMenuDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public OnlineMenuDbContext(DbContextOptions<OnlineMenuDbContext> options)
            : base(options)
        {

        }

        public DbSet<UserDrink> UsersDrinks { get; set; } = null!;

        public DbSet<UserFood> UsersFood { get; set; } = null!;

        public DbSet<Drink> Drinks { get; set; } = null!;

        public DbSet<Food> Food { get; set; } = null!;

        public DbSet<DrinkCategory> DrinksCategories { get; set; } = null!;

        public DbSet<FoodCategory> FoodCategories { get; set; } = null!;

        public DbSet<Manager> Managers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            Assembly configAsembly = Assembly.GetAssembly(typeof(OnlineMenuDbContext)) ?? Assembly.GetExecutingAssembly();
            builder.ApplyConfigurationsFromAssembly(configAsembly);

            base.OnModelCreating(builder);
        }
    }
}
