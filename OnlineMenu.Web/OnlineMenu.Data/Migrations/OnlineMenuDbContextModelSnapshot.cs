﻿#nullable disable

namespace OnlineMenu.Data.Migrations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Infrastructure;

	[DbContext(typeof(OnlineMenuDbContext))]
    partial class OnlineMenuDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("OnlineMenu.Data.Models.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("OnlineMenu.Data.Models.Drink", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("DrinkCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<bool>("IsAlcoholic")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("Milliliters")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("DrinkCategoryId");

                    b.ToTable("Drinks");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e52ee27b-884c-4911-97e4-1c6ac9763dc9"),
                            Description = "Mineral Water",
                            DrinkCategoryId = 1,
                            ImageUrl = "/img/drinks/Devin.jpg",
                            IsAlcoholic = false,
                            IsDeleted = false,
                            Milliliters = 330,
                            Name = "Devin",
                            Price = 1.80m
                        },
                        new
                        {
                            Id = new Guid("2894c5f9-092c-4926-a92e-fa8ec5ca82a1"),
                            Description = "Sparkling Water",
                            DrinkCategoryId = 1,
                            ImageUrl = "/img/drinks/DevinSparkling.jpg",
                            IsAlcoholic = false,
                            IsDeleted = false,
                            Milliliters = 330,
                            Name = "Devin",
                            Price = 2.00m
                        },
                        new
                        {
                            Id = new Guid("d8687829-2896-4ff0-ba6a-872f31772f9e"),
                            Description = "Classic or sugar free",
                            DrinkCategoryId = 2,
                            ImageUrl = "/img/drinks/cocacola.jpg",
                            IsAlcoholic = false,
                            IsDeleted = false,
                            Milliliters = 330,
                            Name = "Coca Cola",
                            Price = 2.50m
                        },
                        new
                        {
                            Id = new Guid("ea6091f0-88fc-4a3f-8b0b-8f75b1144e78"),
                            Description = "Flavour by choice",
                            DrinkCategoryId = 2,
                            ImageUrl = "/img/drinks/Fanta.jpg",
                            IsAlcoholic = false,
                            IsDeleted = false,
                            Milliliters = 330,
                            Name = "Fanta",
                            Price = 2.50m
                        },
                        new
                        {
                            Id = new Guid("d4816767-257c-44fd-bef6-3cfc42769849"),
                            Description = "Flavour by choice",
                            DrinkCategoryId = 2,
                            ImageUrl = "/img/drinks/popsoda.jpg",
                            IsAlcoholic = false,
                            IsDeleted = false,
                            Milliliters = 330,
                            Name = "Pop Soda",
                            Price = 2.50m
                        },
                        new
                        {
                            Id = new Guid("645703bd-cb2a-41d5-961d-4f16ebcbf37e"),
                            Description = "Espresso, Americano or Decaf",
                            DrinkCategoryId = 3,
                            ImageUrl = "/img/drinks/coffee.jpg",
                            IsAlcoholic = false,
                            IsDeleted = false,
                            Milliliters = 50,
                            Name = "Coffee",
                            Price = 2.00m
                        },
                        new
                        {
                            Id = new Guid("bd726805-bf0a-4dac-b19d-d94105ec14d5"),
                            Description = "Cocoa powder by choice",
                            DrinkCategoryId = 3,
                            ImageUrl = "/img/drinks/Cappuccino.jpg",
                            IsAlcoholic = false,
                            IsDeleted = false,
                            Milliliters = 80,
                            Name = "Cappuccino",
                            Price = 2.60m
                        },
                        new
                        {
                            Id = new Guid("b1d9d70a-a7a5-45b4-b1b6-dc4a8f33fbb1"),
                            Description = "Herbs or Fruit flavour",
                            DrinkCategoryId = 3,
                            ImageUrl = "/img/drinks/Tea.png",
                            IsAlcoholic = false,
                            IsDeleted = false,
                            Milliliters = 80,
                            Name = "Tea",
                            Price = 2.00m
                        },
                        new
                        {
                            Id = new Guid("ef888509-f12f-4ac2-b011-8da99d4f8dad"),
                            Description = "Draught beer",
                            DrinkCategoryId = 4,
                            ImageUrl = "/img/drinks/BeerSmall.jpg",
                            IsAlcoholic = true,
                            IsDeleted = false,
                            Milliliters = 330,
                            Name = "Carlsberg",
                            Price = 3.00m
                        },
                        new
                        {
                            Id = new Guid("81cd5d5f-c1a2-4977-979e-41eeb78f2e0a"),
                            Description = "Draught beer",
                            DrinkCategoryId = 4,
                            ImageUrl = "/img/drinks/Beer.jpg",
                            IsAlcoholic = true,
                            IsDeleted = false,
                            Milliliters = 500,
                            Name = "Carlsberg",
                            Price = 4.50m
                        },
                        new
                        {
                            Id = new Guid("8313df9a-7597-4e67-85c4-e75ccdf420b5"),
                            Description = "12 years aged whisky",
                            DrinkCategoryId = 5,
                            ImageUrl = "/img/drinks/Singleton.jpg",
                            IsAlcoholic = true,
                            IsDeleted = false,
                            Milliliters = 50,
                            Name = "Singleton",
                            Price = 15.00m
                        },
                        new
                        {
                            Id = new Guid("95e5f9ab-8351-4c16-bd07-35ac4b68f62c"),
                            Description = "15 years aged whisky",
                            DrinkCategoryId = 5,
                            ImageUrl = "/img/drinks/Glenfiddich.jpg",
                            IsAlcoholic = true,
                            IsDeleted = false,
                            Milliliters = 50,
                            Name = "Glenfiddich",
                            Price = 18.00m
                        },
                        new
                        {
                            Id = new Guid("af55ec9a-1b0f-404e-85f3-fc9017eb0f06"),
                            Description = "Scotch whisky",
                            DrinkCategoryId = 5,
                            ImageUrl = "/img/drinks/the-sassenach.jpg",
                            IsAlcoholic = true,
                            IsDeleted = false,
                            Milliliters = 50,
                            Name = "The Sassenach",
                            Price = 14.00m
                        },
                        new
                        {
                            Id = new Guid("342fef96-bc35-4ed4-9320-ea056271e0e0"),
                            Description = "Vodka with premium quality and smooth taste",
                            DrinkCategoryId = 6,
                            ImageUrl = "/img/drinks/Beluga.jpg",
                            IsAlcoholic = true,
                            IsDeleted = false,
                            Milliliters = 50,
                            Name = "Beluga",
                            Price = 15.00m
                        },
                        new
                        {
                            Id = new Guid("7a92bc0a-1c67-4476-b302-ea0e6bd58d1b"),
                            Description = "Smoothness, subtle sweetness, and clean finish",
                            DrinkCategoryId = 6,
                            ImageUrl = "/img/drinks/Belvedere.jpg",
                            IsAlcoholic = true,
                            IsDeleted = false,
                            Milliliters = 50,
                            Name = "Belvedere",
                            Price = 15.00m
                        },
                        new
                        {
                            Id = new Guid("43cd6665-78ee-4127-b0b1-1c027a285c25"),
                            Description = "Smooth taste with subtle sweetness and a hint of almond",
                            DrinkCategoryId = 6,
                            ImageUrl = "/img/drinks/Grey-Goose.jpg",
                            IsAlcoholic = true,
                            IsDeleted = false,
                            Milliliters = 50,
                            Name = "Grey Goose",
                            Price = 18.00m
                        },
                        new
                        {
                            Id = new Guid("5bb5d7e7-0950-4a3c-b637-ea86bb513a49"),
                            Description = "London Dry Gin",
                            DrinkCategoryId = 7,
                            ImageUrl = "/img/drinks/Bombay-Sapphire.jpg",
                            IsAlcoholic = true,
                            IsDeleted = false,
                            Milliliters = 50,
                            Name = "Bombay Sapphire",
                            Price = 8.00m
                        },
                        new
                        {
                            Id = new Guid("5242406f-51b5-42ae-9b61-d611e62caac3"),
                            Description = "London Dry Gin",
                            DrinkCategoryId = 7,
                            ImageUrl = "/img/drinks/Brokers.jpg",
                            IsAlcoholic = true,
                            IsDeleted = false,
                            Milliliters = 50,
                            Name = "Brokers",
                            Price = 8.00m
                        },
                        new
                        {
                            Id = new Guid("6b0b9619-77ca-425e-a914-9c3df2714475"),
                            Description = "Red, White, or Rose",
                            DrinkCategoryId = 8,
                            ImageUrl = "/img/drinks/Wine.jpg",
                            IsAlcoholic = true,
                            IsDeleted = false,
                            Milliliters = 350,
                            Name = "Minkov Brothers Wine",
                            Price = 6.00m
                        },
                        new
                        {
                            Id = new Guid("22ae7a8f-c9cc-4fc1-a2a1-dac92f36e528"),
                            Description = "Consists of equal parts of three main ingredients: gin, campari, and sweet vermouth",
                            DrinkCategoryId = 9,
                            ImageUrl = "/img/drinks/negroni.jpg",
                            IsAlcoholic = true,
                            IsDeleted = false,
                            Milliliters = 200,
                            Name = "Negroni",
                            Price = 8.00m
                        },
                        new
                        {
                            Id = new Guid("eb5b6eae-5d12-4ba5-957d-01f4608174e6"),
                            Description = "Consists of aperol, prosecco, club soda, ice cubes, orange slice",
                            DrinkCategoryId = 9,
                            ImageUrl = "/img/drinks/Aperol.Spritz.jpg",
                            IsAlcoholic = true,
                            IsDeleted = false,
                            Milliliters = 250,
                            Name = "Aperol Spritz",
                            Price = 8.00m
                        });
                });

            modelBuilder.Entity("OnlineMenu.Data.Models.DrinkCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("DrinksCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDeleted = false,
                            Name = "Water"
                        },
                        new
                        {
                            Id = 2,
                            IsDeleted = false,
                            Name = "Soft Drinks"
                        },
                        new
                        {
                            Id = 3,
                            IsDeleted = false,
                            Name = "Hot Drinks"
                        },
                        new
                        {
                            Id = 4,
                            IsDeleted = false,
                            Name = "Beer"
                        },
                        new
                        {
                            Id = 5,
                            IsDeleted = false,
                            Name = "Whisky"
                        },
                        new
                        {
                            Id = 6,
                            IsDeleted = false,
                            Name = "Vodka"
                        },
                        new
                        {
                            Id = 7,
                            IsDeleted = false,
                            Name = "Gin"
                        },
                        new
                        {
                            Id = 8,
                            IsDeleted = false,
                            Name = "Wine"
                        },
                        new
                        {
                            Id = 9,
                            IsDeleted = false,
                            Name = "Cocktails"
                        });
                });

            modelBuilder.Entity("OnlineMenu.Data.Models.Food", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("FoodCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FoodCategoryId");

                    b.ToTable("Food");

                    b.HasData(
                        new
                        {
                            Id = new Guid("19935328-fecf-411d-aa07-7a4148e26072"),
                            Description = "Romaine lettuce, croutons, parmesan cheese and a dressing consisting of olive oil, lemon juice, garlic, worcestershire sauce",
                            FoodCategoryId = 1,
                            ImageUrl = "/img/food/caesarsalad.jpg",
                            IsDeleted = false,
                            Name = "Caesar Salad",
                            Price = 12.00m,
                            Weight = 400
                        },
                        new
                        {
                            Id = new Guid("8bfe4fdf-60db-49c9-9ab1-5284c928716a"),
                            Description = "Tomatoes, mozzarella cheese, basil leaves, olive oil, pesto",
                            FoodCategoryId = 1,
                            ImageUrl = "/img/food/capresesalad.jpg",
                            IsDeleted = false,
                            Name = "Caprese Salad",
                            Price = 12.00m,
                            Weight = 450
                        },
                        new
                        {
                            Id = new Guid("68c56b3f-dba0-48b1-a0d0-9ca393d9d507"),
                            Description = "With ketchup",
                            FoodCategoryId = 2,
                            ImageUrl = "/img/food/frenchfries.jpg",
                            IsDeleted = false,
                            Name = "French Fries",
                            Price = 6.50m,
                            Weight = 300
                        },
                        new
                        {
                            Id = new Guid("b5c74688-3fb8-4be9-9904-4923f340d8e5"),
                            Description = "With ketchup and yogurt sauce",
                            FoodCategoryId = 2,
                            ImageUrl = "/img/food/chickennugets.jpeg",
                            IsDeleted = false,
                            Name = "Chicken Nuggets",
                            Price = 8.00m,
                            Weight = 350
                        },
                        new
                        {
                            Id = new Guid("9e7f1108-ec05-476c-b045-a109b3172a38"),
                            Description = "With corn flakes and ketchup",
                            FoodCategoryId = 2,
                            ImageUrl = "/img/food/crustedchickenstrips.jpg",
                            IsDeleted = false,
                            Name = "Crusted Chicken Strips",
                            Price = 10.00m,
                            Weight = 350
                        },
                        new
                        {
                            Id = new Guid("6d197093-80e2-4bfb-aaef-7ae8b8cf4f1c"),
                            Description = "Grilled chicken breasts topped with mozzarella cheese, tomato slices, fresh basil leaves, pesto",
                            FoodCategoryId = 3,
                            ImageUrl = "/img/food/chickencaprese.jpg",
                            IsDeleted = false,
                            Name = "Chicken Caprese",
                            Price = 11.50m,
                            Weight = 400
                        },
                        new
                        {
                            Id = new Guid("1bd7c555-381f-4672-905e-ffa77efaa4fa"),
                            Description = "Traditional Austrian dish made with a thinly pounded and breaded veal cutlet, french fries, yogurt sauce",
                            FoodCategoryId = 3,
                            ImageUrl = "/img/food/Vienneseschnitzel.png",
                            IsDeleted = false,
                            Name = "Viennese Schnitzel",
                            Price = 15.00m,
                            Weight = 500
                        },
                        new
                        {
                            Id = new Guid("b1dbe889-07fb-461f-9181-48ee594fa9bc"),
                            Description = "Side dish - fresh mushrooms, mushrooms sauce, french fries, carrot and broccoli",
                            FoodCategoryId = 3,
                            ImageUrl = "/img/food/beefsteak.jpg",
                            IsDeleted = false,
                            Name = "Beef Steak",
                            Price = 29.99m,
                            Weight = 650
                        },
                        new
                        {
                            Id = new Guid("a24c1e95-5600-4db9-950f-550875473804"),
                            Description = "Fresh buffalo mozzarella cheese, tomato sauce, basil leaves",
                            FoodCategoryId = 4,
                            ImageUrl = "/img/food/PizzaBufala.jpg",
                            IsDeleted = false,
                            Name = "Pizza Bufala",
                            Price = 14.99m,
                            Weight = 550
                        },
                        new
                        {
                            Id = new Guid("761e4037-38af-464b-8dc5-3d7d29322b91"),
                            Description = "Mozzarella cheese, tomato sauce, spicy cured Italian sausage",
                            FoodCategoryId = 4,
                            ImageUrl = "/img/food/PizzaPeperoni.jpg",
                            IsDeleted = false,
                            Name = "Pizza Pepperoni",
                            Price = 14.99m,
                            Weight = 550
                        },
                        new
                        {
                            Id = new Guid("08160848-2273-4617-8fac-5582b4de208c"),
                            Description = "Spaghetti noodles topped with a meat-based sauce ragù alla bolognese",
                            FoodCategoryId = 5,
                            ImageUrl = "/img/food/spaghettiBolognese.jpg",
                            IsDeleted = false,
                            Name = "Spaghetti Bolognese",
                            Price = 12.00m,
                            Weight = 440
                        },
                        new
                        {
                            Id = new Guid("89df10dc-3de5-4094-bf60-20d115da8abb"),
                            Description = "Spaghetti pasta, eggs, pecorino romano cheese, guanciale (cured pork cheek), black pepper",
                            FoodCategoryId = 5,
                            ImageUrl = "/img/food/SpaghettiCarbonara.jpg",
                            IsDeleted = false,
                            Name = "Spaghetti Carbonara",
                            Price = 11.00m,
                            Weight = 440
                        },
                        new
                        {
                            Id = new Guid("6af823c9-6453-4be4-b791-e5185fbe083a"),
                            Description = "Beef burger with french fries, fresh salad, cheddar",
                            FoodCategoryId = 6,
                            ImageUrl = "/img/food/BeebBurger.jpg",
                            IsDeleted = false,
                            Name = "Beef Burger",
                            Price = 18.00m,
                            Weight = 480
                        },
                        new
                        {
                            Id = new Guid("ddefd4af-4405-424b-a930-0fcb459c8d7f"),
                            Description = "Pork burger with fresh salad and cheddar",
                            FoodCategoryId = 6,
                            ImageUrl = "/img/food/porkburger.jpg",
                            IsDeleted = false,
                            Name = "Pork Burger",
                            Price = 14.00m,
                            Weight = 430
                        },
                        new
                        {
                            Id = new Guid("f419b888-b002-40e7-a742-491f9473b501"),
                            Description = "Chocolate souffle with vanilla ice cream",
                            FoodCategoryId = 7,
                            ImageUrl = "/img/food/Soufle.jpg",
                            IsDeleted = false,
                            Name = "Souffle",
                            Price = 6.50m,
                            Weight = 250
                        },
                        new
                        {
                            Id = new Guid("34872e0a-6dcf-4229-99b0-c13f8e76af39"),
                            Description = "Consists of layers of coffee-soaked ladyfinger biscuits, a creamy mixture made with mascarpone cheese, flavored with a hint of liqueur, and dusted with cocoa powder on top",
                            FoodCategoryId = 7,
                            ImageUrl = "/img/food/tiramisu.jpg",
                            IsDeleted = false,
                            Name = "Tiramisu",
                            Price = 6.90m,
                            Weight = 300
                        },
                        new
                        {
                            Id = new Guid("e55098c6-d8d4-4fe0-b1a2-108a9686b1f7"),
                            Description = "Cake with intense chocolate flavor and smooth, creamy texture",
                            FoodCategoryId = 7,
                            ImageUrl = "img/food/Garash.jpg",
                            IsDeleted = false,
                            Name = "Garash",
                            Price = 5.90m,
                            Weight = 200
                        });
                });

            modelBuilder.Entity("OnlineMenu.Data.Models.FoodCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("FoodCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDeleted = false,
                            Name = "Salads"
                        },
                        new
                        {
                            Id = 2,
                            IsDeleted = false,
                            Name = "Starters"
                        },
                        new
                        {
                            Id = 3,
                            IsDeleted = false,
                            Name = "Main Dishes"
                        },
                        new
                        {
                            Id = 4,
                            IsDeleted = false,
                            Name = "Pizza"
                        },
                        new
                        {
                            Id = 5,
                            IsDeleted = false,
                            Name = "Spaghetti"
                        },
                        new
                        {
                            Id = 6,
                            IsDeleted = false,
                            Name = "Burgers"
                        },
                        new
                        {
                            Id = 7,
                            IsDeleted = false,
                            Name = "Desserts"
                        });
                });

            modelBuilder.Entity("OnlineMenu.Data.Models.Manager", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("OnlineMenu.Data.Models.UserDrink", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DrinkId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "DrinkId");

                    b.HasIndex("DrinkId");

                    b.ToTable("UsersDrinks");
                });

            modelBuilder.Entity("OnlineMenu.Data.Models.UserFood", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FoodId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "FoodId");

                    b.HasIndex("FoodId");

                    b.ToTable("UsersFood");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("OnlineMenu.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("OnlineMenu.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineMenu.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("OnlineMenu.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnlineMenu.Data.Models.Drink", b =>
                {
                    b.HasOne("OnlineMenu.Data.Models.DrinkCategory", "DrinkCategory")
                        .WithMany("Drinks")
                        .HasForeignKey("DrinkCategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("DrinkCategory");
                });

            modelBuilder.Entity("OnlineMenu.Data.Models.Food", b =>
                {
                    b.HasOne("OnlineMenu.Data.Models.FoodCategory", "Category")
                        .WithMany("Food")
                        .HasForeignKey("FoodCategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("OnlineMenu.Data.Models.Manager", b =>
                {
                    b.HasOne("OnlineMenu.Data.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("OnlineMenu.Data.Models.UserDrink", b =>
                {
                    b.HasOne("OnlineMenu.Data.Models.Drink", "Drink")
                        .WithMany()
                        .HasForeignKey("DrinkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineMenu.Data.Models.ApplicationUser", "User")
                        .WithMany("FavouriteDrinks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Drink");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OnlineMenu.Data.Models.UserFood", b =>
                {
                    b.HasOne("OnlineMenu.Data.Models.Food", "Food")
                        .WithMany()
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineMenu.Data.Models.ApplicationUser", "User")
                        .WithMany("FavourtiteFood")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Food");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OnlineMenu.Data.Models.ApplicationUser", b =>
                {
                    b.Navigation("FavouriteDrinks");

                    b.Navigation("FavourtiteFood");
                });

            modelBuilder.Entity("OnlineMenu.Data.Models.DrinkCategory", b =>
                {
                    b.Navigation("Drinks");
                });

            modelBuilder.Entity("OnlineMenu.Data.Models.FoodCategory", b =>
                {
                    b.Navigation("Food");
                });
#pragma warning restore 612, 618
        }
    }
}
