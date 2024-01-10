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

            builder.HasData(this.CreateFood());
        }

        private Food[] CreateFood()
        {
            ICollection<Food> foodCollection = new HashSet<Food>();

            Food food;

            food = new Food
            {
                Name = "Caesar Salad",
                Weight = 400,
                Price = 12.00m,
                Description = "Romaine lettuce, croutons, parmesan cheese and a dressing consisting of olive oil, lemon juice, garlic, worcestershire sauce",
                IsDeleted = false,
                ImageUrl = "/img/food/caesarsalad.jpg",
                FoodCategoryId = 1
            };
            foodCollection.Add(food);

            food = new Food
            {
                Name = "Caprese Salad",
                Weight = 450,
                Price = 12.00m,
                Description = "Tomatoes, mozzarella cheese, basil leaves, olive oil, pesto",
                IsDeleted = false,
                ImageUrl = "/img/food/capresesalad.jpg",
                FoodCategoryId = 1
            };
            foodCollection.Add(food);

            food = new Food
            {
                Name = "French Fries",
                Weight = 300,
                Price = 6.50m,
                Description = "With ketchup",
                IsDeleted = false,
                ImageUrl = "/img/food/frenchfries.jpg",
                FoodCategoryId = 2
            };
            foodCollection.Add(food);

            food = new Food
            {
                Name = "Chicken Nuggets",
                Weight = 350,
                Price = 8.00m,
                Description = "With ketchup and yogurt sauce",
                IsDeleted = false,
                ImageUrl = "/img/food/chickennugets.jpeg",
                FoodCategoryId = 2
            };
            foodCollection.Add(food);

            food = new Food
            {
                Name = "Crusted Chicken Strips",
                Weight = 350,
                Price = 10.00m,
                Description = "With corn flakes and ketchup",
                IsDeleted = false,
                ImageUrl = "/img/food/crustedchickenstrips.jpg",
                FoodCategoryId = 2
            };
            foodCollection.Add(food);

            food = new Food
            {
                Name = "Chicken Caprese",
                Weight = 400,
                Price = 11.50m,
                Description = "Grilled chicken breasts topped with mozzarella cheese, tomato slices, fresh basil leaves, pesto",
                IsDeleted = false,
                ImageUrl = "/img/food/chickencaprese.jpg",
                FoodCategoryId = 3
            };
            foodCollection.Add(food);

            food = new Food
            {
                Name = "Viennese Schnitzel",
                Weight = 500,
                Price = 15.00m,
                Description = "Traditional Austrian dish made with a thinly pounded and breaded veal cutlet, french fries, yogurt sauce",
                IsDeleted = false,
                ImageUrl = "/img/food/Vienneseschnitzel.png",
                FoodCategoryId = 3
            };
            foodCollection.Add(food);

            food = new Food
            {
                Name = "Beef Steak",
                Weight = 650,
                Price = 29.99m,
                Description = "Side dish - fresh mushrooms, mushrooms sauce, french fries, carrot and broccoli",
                IsDeleted = false,
                ImageUrl = "/img/food/beefsteak.jpg",
                FoodCategoryId = 3
            };
            foodCollection.Add(food);

            food = new Food
            {
                Name = "Pizza Bufala",
                Weight = 550,
                Price = 14.99m,
                Description = "Fresh buffalo mozzarella cheese, tomato sauce, basil leaves",
                IsDeleted = false,
                ImageUrl = "/img/food/PizzaBufala.jpg",
                FoodCategoryId = 4
            };
            foodCollection.Add(food);

            food = new Food
            {
                Name = "Pizza Pepperoni",
                Weight = 550,
                Price = 14.99m,
                Description = "Mozzarella cheese, tomato sauce, spicy cured Italian sausage",
                IsDeleted = false,
                ImageUrl = "/img/food/PizzaPeperoni.jpg",
                FoodCategoryId = 4
            };
            foodCollection.Add(food);

            food = new Food
            {
                Name = "Spaghetti Bolognese",
                Weight = 440,
                Price = 12.00m,
                Description = "Spaghetti noodles topped with a meat-based sauce ragù alla bolognese",
                IsDeleted = false,
                ImageUrl = "/img/food/spaghettiBolognese.jpg",
                FoodCategoryId = 5
            };
            foodCollection.Add(food);

            food = new Food
            {
                Name = "Spaghetti Carbonara",
                Weight = 440,
                Price = 11.00m,
                Description = "Spaghetti pasta, eggs, pecorino romano cheese, guanciale (cured pork cheek), black pepper",
                IsDeleted = false,
                ImageUrl = "/img/food/SpaghettiCarbonara.jpg",
                FoodCategoryId = 5
            };
            foodCollection.Add(food);

            food = new Food
            {
                Name = "Beef Burger",
                Weight = 480,
                Price = 18.00m,
                Description = "Beef burger with french fries, fresh salad, cheddar",
                IsDeleted = false,
                ImageUrl = "/img/food/BeebBurger.jpg",
                FoodCategoryId = 6
            };
            foodCollection.Add(food);

            food = new Food
            {
                Name = "Pork Burger",
                Weight = 430,
                Price = 14.00m,
                Description = "Pork burger with fresh salad and cheddar",
                IsDeleted = false,
                ImageUrl = "/img/food/porkburger.jpg",
                FoodCategoryId = 6
            };
            foodCollection.Add(food);

            food = new Food
            {
                Name = "Souffle",
                Weight = 250,
                Price = 6.50m,
                Description = "Chocolate souffle with vanilla ice cream",
                IsDeleted = false,
                ImageUrl = "/img/food/Soufle.jpg",
                FoodCategoryId = 7
            };
            foodCollection.Add(food);

            food = new Food
            {
                Name = "Tiramisu",
                Weight = 300,
                Price = 6.90m,
                Description = "Consists of layers of coffee-soaked ladyfinger biscuits, a creamy mixture made with mascarpone cheese, flavored with a hint of liqueur, and dusted with cocoa powder on top",
                IsDeleted = false,
                ImageUrl = "/img/food/tiramisu.jpg",
                FoodCategoryId = 7
            };
            foodCollection.Add(food);

            food = new Food
            {
                Name = "Garash",
                Weight = 200,
                Price = 5.90m,
                Description = "Cake with intense chocolate flavor and smooth, creamy texture",
                IsDeleted = false,
                ImageUrl = "/img/food/Garash.jpg",
                FoodCategoryId = 7
            };
            foodCollection.Add(food);

            return foodCollection.ToArray();
        }
    }
}
