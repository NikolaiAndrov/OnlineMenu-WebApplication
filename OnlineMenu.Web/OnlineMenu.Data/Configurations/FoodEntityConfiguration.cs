namespace OnlineMenu.Data.Configurations
{
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Microsoft.EntityFrameworkCore;
    using OnlineMenu.Data.Models;

    public class FoodEntityConfiguration : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> builder)
        {
            builder.HasOne(f => f.Category)
                .WithMany(fc => fc.Food)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
