namespace OnlineMenu.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using OnlineMenu.Data.Models;

    public class DrinkCategoryEntityConfiguration : IEntityTypeConfiguration<DrinkCategory>
    {
        public void Configure(EntityTypeBuilder<DrinkCategory> builder)
        {
            builder.HasMany(dc => dc.Drinks)
                .WithOne(d => d.DrinkCategory)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
