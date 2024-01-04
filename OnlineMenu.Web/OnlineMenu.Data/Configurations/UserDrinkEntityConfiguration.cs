namespace OnlineMenu.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using OnlineMenu.Data.Models;

    public class UserDrinkEntityConfiguration : IEntityTypeConfiguration<UserDrink>
    {
        public void Configure(EntityTypeBuilder<UserDrink> builder)
        {
            builder.HasKey(k => new { k.UserId, k.DrinkId });
        }
    }
}
