namespace OnlineMenu.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using OnlineMenu.Data.Models;

    public class DrinkEntityConfiguration : IEntityTypeConfiguration<Drink>
    {
        public void Configure(EntityTypeBuilder<Drink> builder)
        {
            builder.HasOne(d => d.DrinkCategory)
                .WithMany(dc => dc.Drinks)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(this.CreateDrinks());
        }

        private Drink[] CreateDrinks()
        {
            ICollection<Drink> drinks = new HashSet<Drink>();

            Drink drink;

            drink = new Drink
            {
                Name = "Devin",
                Milliliters = 330,
                Price = 1.80m,
                Description = "Mineral Water",
                IsDeleted = false,
                IsAlcoholic = false,
                ImageUrl = "/img/drinks/Devin.jpg",
                DrinkCategoryId = 1
            };
            drinks.Add(drink);

            drink = new Drink
            {
                Name = "Devin",
                Milliliters = 330,
                Price = 2.00m,
                Description = "Sparkling Water",
                IsDeleted = false,
                IsAlcoholic = false,
                ImageUrl = "/img/drinks/DevinSparkling.jpg",
                DrinkCategoryId = 1
            };
            drinks.Add(drink);

            drink = new Drink
            {
                Name = "Coca Cola",
                Milliliters = 330,
                Price = 2.50m,
                Description = "Classic or sugar free",
                IsDeleted = false,
                IsAlcoholic = false,
                ImageUrl = "/img/drinks/cocacola.jpg",
                DrinkCategoryId = 2
            };
            drinks.Add(drink);

            drink = new Drink
            {
                Name = "Fanta",
                Milliliters = 330,
                Price = 2.50m,
                Description = "Flavour by choice",
                IsDeleted = false,
                IsAlcoholic = false,
                ImageUrl = "/img/drinks/Fanta.jpg",
                DrinkCategoryId = 2
            };
            drinks.Add(drink);

            drink = new Drink
            {
                Name = "Pop Soda",
                Milliliters = 330,
                Price = 2.50m,
                Description = "Flavour by choice",
                IsDeleted = false,
                IsAlcoholic = false,
                ImageUrl = "/img/drinks/popsoda.jpg",
                DrinkCategoryId = 2
            };
            drinks.Add(drink);

            drink = new Drink
            {
                Name = "Coffee",
                Milliliters = 50,
                Price = 2.00m,
                Description = "Espresso, Americano or Decaf",
                IsDeleted = false,
                IsAlcoholic = false,
                ImageUrl = "/img/drinks/coffee.jpg",
                DrinkCategoryId = 3
            };
            drinks.Add(drink);

            drink = new Drink
            {
                Name = "Cappuccino",
                Milliliters = 80,
                Price = 2.60m,
                Description = "Cocoa powder by choice",
                IsDeleted = false,
                IsAlcoholic = false,
                ImageUrl = "/img/drinks/Cappuccino.jpg",
                DrinkCategoryId = 3
            };
            drinks.Add(drink);

            drink = new Drink
            {
                Name = "Tea",
                Milliliters = 80,
                Price = 2.00m,
                Description = "Herbs or Fruit flavour",
                IsDeleted = false,
                IsAlcoholic = false,
                ImageUrl = "/img/drinks/Tea.png",
                DrinkCategoryId = 3
            };
            drinks.Add(drink);

            drink = new Drink
            {
                Name = "Carlsberg",
                Milliliters = 330,
                Price = 3.00m,
                Description = "Draught beer",
                IsDeleted = false,
                IsAlcoholic = true,
                ImageUrl = "/img/drinks/BeerSmall.jpg",
                DrinkCategoryId = 4
            };
            drinks.Add(drink);

            drink = new Drink
            {
                Name = "Carlsberg",
                Milliliters = 500,
                Price = 4.50m,
                Description = "Draught beer",
                IsDeleted = false,
                IsAlcoholic = true,
                ImageUrl = "/img/drinks/Beer.jpg",
                DrinkCategoryId = 4
            };
            drinks.Add(drink);

            drink = new Drink
            {
                Name = "Singleton",
                Milliliters = 50,
                Price = 15.00m,
                Description = "12 years aged whisky",
                IsDeleted = false,
                IsAlcoholic = true,
                ImageUrl = "/img/drinks/Singleton.jpg",
                DrinkCategoryId = 5
            };
            drinks.Add(drink);

            drink = new Drink
            {
                Name = "Glenfiddich",
                Milliliters = 50,
                Price = 18.00m,
                Description = "15 years aged whisky",
                IsDeleted = false,
                IsAlcoholic = true,
                ImageUrl = "/img/drinks/Glenfiddich.jpg",
                DrinkCategoryId = 5
            };
            drinks.Add(drink);

            drink = new Drink
            {
                Name = "The Sassenach",
                Milliliters = 50,
                Price = 14.00m,
                Description = "Scotch whisky",
                IsDeleted = false,
                IsAlcoholic = true,
                ImageUrl = "/img/drinks/the-sassenach.jpg",
                DrinkCategoryId = 5
            };
            drinks.Add(drink);

            drink = new Drink
            {
                Name = "Beluga",
                Milliliters = 50,
                Price = 15.00m,
                Description = "Vodka with premium quality and smooth taste",
                IsDeleted = false,
                IsAlcoholic = true,
                ImageUrl = "/img/drinks/Beluga.jpg",
                DrinkCategoryId = 6
            };
            drinks.Add(drink);

            drink = new Drink
            {
                Name = "Belvedere",
                Milliliters = 50,
                Price = 15.00m,
                Description = "Smoothness, subtle sweetness, and clean finish",
                IsDeleted = false,
                IsAlcoholic = true,
                ImageUrl = "/img/drinks/Belvedere.jpg",
                DrinkCategoryId = 6
            };
            drinks.Add(drink);

            drink = new Drink
            {
                Name = "Grey Goose",
                Milliliters = 50,
                Price = 18.00m,
                Description = "Smooth taste with subtle sweetness and a hint of almond",
                IsDeleted = false,
                IsAlcoholic = true,
                ImageUrl = "/img/drinks/Grey-Goose.jpg",
                DrinkCategoryId = 6
            };
            drinks.Add(drink);

            drink = new Drink
            {
                Name = "Bombay Sapphire",
                Milliliters = 50,
                Price = 8.00m,
                Description = "London Dry Gin",
                IsDeleted = false,
                IsAlcoholic = true,
                ImageUrl = "/img/drinks/Bombay-Sapphire.jpg",
                DrinkCategoryId = 7
            };
            drinks.Add(drink);

            drink = new Drink
            {
                Name = "Brokers",
                Milliliters = 50,
                Price = 8.00m,
                Description = "London Dry Gin",
                IsDeleted = false,
                IsAlcoholic = true,
                ImageUrl = "/img/drinks/Brokers.jpg",
                DrinkCategoryId = 7
            };
            drinks.Add(drink);

            drink = new Drink
            {
                Name = "Minkov Brothers",
                Milliliters = 350,
                Price = 6.00m,
                Description = "Red, White, or Rose",
                IsDeleted = false,
                IsAlcoholic = true,
                ImageUrl = "/img/drinks/Wine.jpg",
                DrinkCategoryId = 8
            };
            drinks.Add(drink);

            drink = new Drink
            {
                Name = "Negroni",
                Milliliters = 200,
                Price = 8.00m,
                Description = "Consists of equal parts of three main ingredients: gin, campari, and sweet vermouth",
                IsDeleted = false,
                IsAlcoholic = true,
                ImageUrl = "/img/drinks/negroni.jpg",
                DrinkCategoryId = 9
            };
            drinks.Add(drink);

            drink = new Drink
            {
                Name = "Aperol Spritz",
                Milliliters = 250,
                Price = 8.00m,
                Description = "Consists of aperol, prosecco, club soda, ice cubes, orange slice",
                IsDeleted = false,
                IsAlcoholic = true,
                ImageUrl = "/img/drinks/Aperol.Spritz.jpg",
                DrinkCategoryId = 9
            };
            drinks.Add(drink);

            return drinks.ToArray();
        }
    }
}
