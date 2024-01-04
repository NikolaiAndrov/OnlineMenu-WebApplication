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

            builder.HasData(this.CreateDrinkCategories());
        }

        private DrinkCategory[] CreateDrinkCategories()
        {
            ICollection<DrinkCategory> drinkCategories = new HashSet<DrinkCategory>();

            DrinkCategory category;

            category = new DrinkCategory
            {
                Id = 1,
                Name = "Water",
                IsDeleted = false
            };
            drinkCategories.Add(category);

            category = new DrinkCategory
            {
                Id = 2,
                Name = "Soft Drinks",
                IsDeleted = false
            };
            drinkCategories.Add(category);

            category = new DrinkCategory
            {
                Id = 3,
                Name = "Hot Drinks",
                IsDeleted = false
            };
            drinkCategories.Add(category);

            category = new DrinkCategory
            {
                Id = 4,
                Name = "Beer",
                IsDeleted = false
            };
            drinkCategories.Add(category);

            category = new DrinkCategory
            {
                Id = 5,
                Name = "Whisky",
                IsDeleted = false
            };
            drinkCategories.Add(category);

            category = new DrinkCategory
            {
                Id = 6,
                Name = "Vodka",
                IsDeleted = false
            };
            drinkCategories.Add(category);

            category = new DrinkCategory
            {
                Id = 7,
                Name = "Gin",
                IsDeleted = false
            };
            drinkCategories.Add(category);


            category = new DrinkCategory
            {
                Id = 8,
                Name = "Wine",
                IsDeleted = false
            };
            drinkCategories.Add(category);

            category = new DrinkCategory
            {
                Id = 9,
                Name = "Cocktails",
                IsDeleted = false
            };
            drinkCategories.Add(category);

            return drinkCategories.ToArray();
        }
    }
}
