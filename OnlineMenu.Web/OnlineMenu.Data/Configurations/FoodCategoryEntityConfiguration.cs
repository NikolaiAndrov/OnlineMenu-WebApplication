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

            builder.HasData(this.CreateFoodCategories());
        }

        private FoodCategory[] CreateFoodCategories()
        {
            ICollection<FoodCategory> foodCategories = new HashSet<FoodCategory>();

            FoodCategory category;

            category = new FoodCategory
            {
                Id = 1,
                Name = "Salads",
                IsDeleted = false,
            };
            foodCategories.Add(category);

            category = new FoodCategory
            {
                Id = 2,
                Name = "Starters",
                IsDeleted = false,
            };
            foodCategories.Add(category);

            category = new FoodCategory
            {
                Id = 3,
                Name = "Main Dishes",
                IsDeleted = false,
            };
            foodCategories.Add(category);

            category = new FoodCategory
            {
                Id = 4,
                Name = "Pizza",
                IsDeleted = false,
            };
            foodCategories.Add(category);

            category = new FoodCategory
            {
                Id = 5,
                Name = "Spaghetti",
                IsDeleted = false,
            };
            foodCategories.Add(category);

            category = new FoodCategory
            {
                Id = 6,
                Name = "Burgers",
                IsDeleted = false,
            };
            foodCategories.Add(category);

            category = new FoodCategory
            {
                Id = 7,
                Name = "Desserts",
                IsDeleted = false,
            };
            foodCategories.Add(category);

            return foodCategories.ToArray();
        }
    }
}
