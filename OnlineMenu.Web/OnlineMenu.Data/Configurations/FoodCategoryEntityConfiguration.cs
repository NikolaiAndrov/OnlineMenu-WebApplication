namespace OnlineMenu.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using OnlineMenu.Data.Models;

    public class FoodCategoryEntityConfiguration : IEntityTypeConfiguration<FoodCategory>
    {
        public void Configure(EntityTypeBuilder<FoodCategory> builder)
        {
            builder.HasMany(fc => fc.Food)
                .WithOne(f => f.Category)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
