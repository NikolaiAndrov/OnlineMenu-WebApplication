#nullable disable

namespace OnlineMenu.Data.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddUserFirstNameAndLastNameRemoveManagerFirstNameAndLastName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: new Guid("22ae7a8f-c9cc-4fc1-a2a1-dac92f36e528"));

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: new Guid("2894c5f9-092c-4926-a92e-fa8ec5ca82a1"));

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: new Guid("342fef96-bc35-4ed4-9320-ea056271e0e0"));

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: new Guid("43cd6665-78ee-4127-b0b1-1c027a285c25"));

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: new Guid("5242406f-51b5-42ae-9b61-d611e62caac3"));

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: new Guid("5bb5d7e7-0950-4a3c-b637-ea86bb513a49"));

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: new Guid("645703bd-cb2a-41d5-961d-4f16ebcbf37e"));

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: new Guid("6b0b9619-77ca-425e-a914-9c3df2714475"));

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: new Guid("7a92bc0a-1c67-4476-b302-ea0e6bd58d1b"));

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: new Guid("81cd5d5f-c1a2-4977-979e-41eeb78f2e0a"));

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: new Guid("8313df9a-7597-4e67-85c4-e75ccdf420b5"));

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: new Guid("95e5f9ab-8351-4c16-bd07-35ac4b68f62c"));

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: new Guid("af55ec9a-1b0f-404e-85f3-fc9017eb0f06"));

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: new Guid("b1d9d70a-a7a5-45b4-b1b6-dc4a8f33fbb1"));

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: new Guid("bd726805-bf0a-4dac-b19d-d94105ec14d5"));

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: new Guid("d4816767-257c-44fd-bef6-3cfc42769849"));

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: new Guid("d8687829-2896-4ff0-ba6a-872f31772f9e"));

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: new Guid("e52ee27b-884c-4911-97e4-1c6ac9763dc9"));

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: new Guid("ea6091f0-88fc-4a3f-8b0b-8f75b1144e78"));

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: new Guid("eb5b6eae-5d12-4ba5-957d-01f4608174e6"));

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: new Guid("ef888509-f12f-4ac2-b011-8da99d4f8dad"));

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: new Guid("08160848-2273-4617-8fac-5582b4de208c"));

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: new Guid("19935328-fecf-411d-aa07-7a4148e26072"));

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: new Guid("1bd7c555-381f-4672-905e-ffa77efaa4fa"));

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: new Guid("34872e0a-6dcf-4229-99b0-c13f8e76af39"));

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: new Guid("68c56b3f-dba0-48b1-a0d0-9ca393d9d507"));

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: new Guid("6af823c9-6453-4be4-b791-e5185fbe083a"));

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: new Guid("6d197093-80e2-4bfb-aaef-7ae8b8cf4f1c"));

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: new Guid("761e4037-38af-464b-8dc5-3d7d29322b91"));

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: new Guid("89df10dc-3de5-4094-bf60-20d115da8abb"));

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: new Guid("8bfe4fdf-60db-49c9-9ab1-5284c928716a"));

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: new Guid("9e7f1108-ec05-476c-b045-a109b3172a38"));

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: new Guid("a24c1e95-5600-4db9-950f-550875473804"));

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: new Guid("b1dbe889-07fb-461f-9181-48ee594fa9bc"));

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: new Guid("b5c74688-3fb8-4be9-9904-4923f340d8e5"));

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: new Guid("ddefd4af-4405-424b-a930-0fcb459c8d7f"));

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: new Guid("e55098c6-d8d4-4fe0-b1a2-108a9686b1f7"));

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: new Guid("f419b888-b002-40e7-a742-491f9473b501"));

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Managers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Managers");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "FirstName");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "LastName");

            migrationBuilder.InsertData(
                table: "Drinks",
                columns: new[] { "Id", "Description", "DrinkCategoryId", "ImageUrl", "IsAlcoholic", "IsDeleted", "Milliliters", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("2227d3ed-f6ce-45a6-91af-43cb72a4d9f0"), "Smoothness, subtle sweetness, and clean finish", 6, "/img/drinks/Belvedere.jpg", true, false, 50, "Belvedere", 15.00m },
                    { new Guid("3019f625-adc9-400b-b10b-6592b833cc5c"), "Scotch whisky", 5, "/img/drinks/the-sassenach.jpg", true, false, 50, "The Sassenach", 14.00m },
                    { new Guid("429968ed-2dd0-447e-97f9-5277b17ca4d2"), "Mineral Water", 1, "/img/drinks/Devin.jpg", false, false, 330, "Devin", 1.80m },
                    { new Guid("46fb9e42-d3da-4c23-a73a-303d7d68dcc6"), "Draught beer", 4, "/img/drinks/Beer.jpg", true, false, 500, "Carlsberg", 4.50m },
                    { new Guid("4bc89cf6-6783-40d6-bf90-e33fb58ba542"), "Draught beer", 4, "/img/drinks/BeerSmall.jpg", true, false, 330, "Carlsberg", 3.00m },
                    { new Guid("4da5a669-bace-4cfa-a5ad-150f14a7b86b"), "Red, White, or Rose", 8, "/img/drinks/Wine.jpg", true, false, 350, "Minkov Brothers", 6.00m },
                    { new Guid("5c398206-1a1a-4773-a4bf-2550d6bd8d11"), "Consists of equal parts of three main ingredients: gin, campari, and sweet vermouth", 9, "/img/drinks/negroni.jpg", true, false, 200, "Negroni", 8.00m },
                    { new Guid("71ff2b16-e3ba-4d37-bcce-cd4ecea6754c"), "Vodka with premium quality and smooth taste", 6, "/img/drinks/Beluga.jpg", true, false, 50, "Beluga", 15.00m },
                    { new Guid("89d18d77-9010-4ef1-924e-bafe9195f809"), "12 years aged whisky", 5, "/img/drinks/Singleton.jpg", true, false, 50, "Singleton", 15.00m },
                    { new Guid("8a976cda-c255-4c99-835d-a0d5459c7584"), "Flavour by choice", 2, "/img/drinks/Fanta.jpg", false, false, 330, "Fanta", 2.50m },
                    { new Guid("93e4f05a-d9c1-419d-a812-dcc0a820ec27"), "London Dry Gin", 7, "/img/drinks/Bombay-Sapphire.jpg", true, false, 50, "Bombay Sapphire", 8.00m },
                    { new Guid("9801e735-1bed-45ed-9063-ef417fd70e30"), "Smooth taste with subtle sweetness and a hint of almond", 6, "/img/drinks/Grey-Goose.jpg", true, false, 50, "Grey Goose", 18.00m },
                    { new Guid("a8f2e35f-bdfa-4327-b8dc-8f52663ee4cf"), "Consists of aperol, prosecco, club soda, ice cubes, orange slice", 9, "/img/drinks/Aperol.Spritz.jpg", true, false, 250, "Aperol Spritz", 8.00m },
                    { new Guid("b6282fac-f78d-46b0-884c-324b15f6dcb8"), "Cocoa powder by choice", 3, "/img/drinks/Cappuccino.jpg", false, false, 80, "Cappuccino", 2.60m },
                    { new Guid("bc44841c-b7cf-4fbf-8340-f2a13d63b80c"), "London Dry Gin", 7, "/img/drinks/Brokers.jpg", true, false, 50, "Brokers", 8.00m },
                    { new Guid("bee246b9-b84f-4f98-bdc0-ae22dcfa2676"), "Espresso, Americano or Decaf", 3, "/img/drinks/coffee.jpg", false, false, 50, "Coffee", 2.00m },
                    { new Guid("cfdae2fb-537c-4278-bc7a-a7653ad2cfb8"), "Flavour by choice", 2, "/img/drinks/popsoda.jpg", false, false, 330, "Pop Soda", 2.50m },
                    { new Guid("d3eebf99-fb1b-4a4b-a109-99993faffb86"), "Herbs or Fruit flavour", 3, "/img/drinks/Tea.png", false, false, 80, "Tea", 2.00m },
                    { new Guid("e134ae3f-7264-4be8-ac73-3caacd854556"), "15 years aged whisky", 5, "/img/drinks/Glenfiddich.jpg", true, false, 50, "Glenfiddich", 18.00m },
                    { new Guid("ed635bef-260f-48c3-a0e3-c2fbdf2625b7"), "Sparkling Water", 1, "/img/drinks/DevinSparkling.jpg", false, false, 330, "Devin", 2.00m },
                    { new Guid("f38e4bb6-1b88-4174-93e1-07243d46a096"), "Classic or sugar free", 2, "/img/drinks/cocacola.jpg", false, false, 330, "Coca Cola", 2.50m }
                });

            migrationBuilder.InsertData(
                table: "Food",
                columns: new[] { "Id", "Description", "FoodCategoryId", "ImageUrl", "IsDeleted", "Name", "Price", "Weight" },
                values: new object[,]
                {
                    { new Guid("03714b16-5f0e-4437-bfd9-ff940f82da2a"), "Pork burger with fresh salad and cheddar", 6, "/img/food/porkburger.jpg", false, "Pork Burger", 14.00m, 430 },
                    { new Guid("12510572-decf-4754-aec3-cac332935f36"), "Tomatoes, mozzarella cheese, basil leaves, olive oil, pesto", 1, "/img/food/capresesalad.jpg", false, "Caprese Salad", 12.00m, 450 },
                    { new Guid("18c4b138-fc5d-4563-beac-203c7a41bbaa"), "With ketchup", 2, "/img/food/frenchfries.jpg", false, "French Fries", 6.50m, 300 },
                    { new Guid("52aa0c92-f47f-4fda-b5c7-57e37d765e96"), "Grilled chicken breasts topped with mozzarella cheese, tomato slices, fresh basil leaves, pesto", 3, "/img/food/chickencaprese.jpg", false, "Chicken Caprese", 11.50m, 400 },
                    { new Guid("569d51cc-2649-42c9-8de5-832f2988c2c1"), "Romaine lettuce, croutons, parmesan cheese and a dressing consisting of olive oil, lemon juice, garlic, worcestershire sauce", 1, "/img/food/caesarsalad.jpg", false, "Caesar Salad", 12.00m, 400 },
                    { new Guid("60f0844e-474d-4177-8920-4ae130498616"), "Consists of layers of coffee-soaked ladyfinger biscuits, a creamy mixture made with mascarpone cheese, flavored with a hint of liqueur, and dusted with cocoa powder on top", 7, "/img/food/tiramisu.jpg", false, "Tiramisu", 6.90m, 300 },
                    { new Guid("6507e18e-3bff-45d5-9f85-2bbbf7474ac6"), "Traditional Austrian dish made with a thinly pounded and breaded veal cutlet, french fries, yogurt sauce", 3, "/img/food/Vienneseschnitzel.png", false, "Viennese Schnitzel", 15.00m, 500 },
                    { new Guid("7c3f3ee4-bd26-4cdb-a09f-abe1056bccf8"), "With corn flakes and ketchup", 2, "/img/food/crustedchickenstrips.jpg", false, "Crusted Chicken Strips", 10.00m, 350 },
                    { new Guid("8e5e5542-aa8a-45d5-9dce-e0748a6a1038"), "Beef burger with french fries, fresh salad, cheddar", 6, "/img/food/BeebBurger.jpg", false, "Beef Burger", 18.00m, 480 },
                    { new Guid("97d39561-c6f0-4ea9-96d5-63da05cda77f"), "Fresh buffalo mozzarella cheese, tomato sauce, basil leaves", 4, "/img/food/PizzaBufala.jpg", false, "Pizza Bufala", 14.99m, 550 },
                    { new Guid("a8efd01e-25ef-48ab-844a-30ca627c9c44"), "With ketchup and yogurt sauce", 2, "/img/food/chickennugets.jpeg", false, "Chicken Nuggets", 8.00m, 350 },
                    { new Guid("d524c858-ed11-457d-aef0-15a298a9886b"), "Side dish - fresh mushrooms, mushrooms sauce, french fries, carrot and broccoli", 3, "/img/food/beefsteak.jpg", false, "Beef Steak", 29.99m, 650 },
                    { new Guid("f0b2639a-fec0-498c-ba7d-d089ff2034e8"), "Chocolate souffle with vanilla ice cream", 7, "/img/food/Soufle.jpg", false, "Souffle", 6.50m, 250 },
                    { new Guid("f1a06068-2030-4a58-b3ec-947e1b0d6361"), "Spaghetti noodles topped with a meat-based sauce ragù alla bolognese", 5, "/img/food/spaghettiBolognese.jpg", false, "Spaghetti Bolognese", 12.00m, 440 },
                    { new Guid("f4f7754a-99af-447f-8852-b422b5203e14"), "Cake with intense chocolate flavor and smooth, creamy texture", 7, "/img/food/Garash.jpg", false, "Garash", 5.90m, 200 },
                    { new Guid("fc711ec0-ba08-4098-9ef7-1836c1a2fdea"), "Spaghetti pasta, eggs, pecorino romano cheese, guanciale (cured pork cheek), black pepper", 5, "/img/food/SpaghettiCarbonara.jpg", false, "Spaghetti Carbonara", 11.00m, 440 },
                    { new Guid("fed09852-f896-4826-958c-9f05386a9bd4"), "Mozzarella cheese, tomato sauce, spicy cured Italian sausage", 4, "/img/food/PizzaPeperoni.jpg", false, "Pizza Pepperoni", 14.99m, 550 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: new Guid("2227d3ed-f6ce-45a6-91af-43cb72a4d9f0"));

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: new Guid("3019f625-adc9-400b-b10b-6592b833cc5c"));

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: new Guid("429968ed-2dd0-447e-97f9-5277b17ca4d2"));

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: new Guid("46fb9e42-d3da-4c23-a73a-303d7d68dcc6"));

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: new Guid("4bc89cf6-6783-40d6-bf90-e33fb58ba542"));

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: new Guid("4da5a669-bace-4cfa-a5ad-150f14a7b86b"));

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: new Guid("5c398206-1a1a-4773-a4bf-2550d6bd8d11"));

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: new Guid("71ff2b16-e3ba-4d37-bcce-cd4ecea6754c"));

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: new Guid("89d18d77-9010-4ef1-924e-bafe9195f809"));

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: new Guid("8a976cda-c255-4c99-835d-a0d5459c7584"));

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: new Guid("93e4f05a-d9c1-419d-a812-dcc0a820ec27"));

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: new Guid("9801e735-1bed-45ed-9063-ef417fd70e30"));

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: new Guid("a8f2e35f-bdfa-4327-b8dc-8f52663ee4cf"));

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: new Guid("b6282fac-f78d-46b0-884c-324b15f6dcb8"));

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: new Guid("bc44841c-b7cf-4fbf-8340-f2a13d63b80c"));

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: new Guid("bee246b9-b84f-4f98-bdc0-ae22dcfa2676"));

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: new Guid("cfdae2fb-537c-4278-bc7a-a7653ad2cfb8"));

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: new Guid("d3eebf99-fb1b-4a4b-a109-99993faffb86"));

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: new Guid("e134ae3f-7264-4be8-ac73-3caacd854556"));

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: new Guid("ed635bef-260f-48c3-a0e3-c2fbdf2625b7"));

            migrationBuilder.DeleteData(
                table: "Drinks",
                keyColumn: "Id",
                keyValue: new Guid("f38e4bb6-1b88-4174-93e1-07243d46a096"));

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: new Guid("03714b16-5f0e-4437-bfd9-ff940f82da2a"));

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: new Guid("12510572-decf-4754-aec3-cac332935f36"));

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: new Guid("18c4b138-fc5d-4563-beac-203c7a41bbaa"));

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: new Guid("52aa0c92-f47f-4fda-b5c7-57e37d765e96"));

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: new Guid("569d51cc-2649-42c9-8de5-832f2988c2c1"));

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: new Guid("60f0844e-474d-4177-8920-4ae130498616"));

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: new Guid("6507e18e-3bff-45d5-9f85-2bbbf7474ac6"));

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: new Guid("7c3f3ee4-bd26-4cdb-a09f-abe1056bccf8"));

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: new Guid("8e5e5542-aa8a-45d5-9dce-e0748a6a1038"));

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: new Guid("97d39561-c6f0-4ea9-96d5-63da05cda77f"));

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: new Guid("a8efd01e-25ef-48ab-844a-30ca627c9c44"));

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: new Guid("d524c858-ed11-457d-aef0-15a298a9886b"));

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: new Guid("f0b2639a-fec0-498c-ba7d-d089ff2034e8"));

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: new Guid("f1a06068-2030-4a58-b3ec-947e1b0d6361"));

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: new Guid("f4f7754a-99af-447f-8852-b422b5203e14"));

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: new Guid("fc711ec0-ba08-4098-9ef7-1836c1a2fdea"));

            migrationBuilder.DeleteData(
                table: "Food",
                keyColumn: "Id",
                keyValue: new Guid("fed09852-f896-4826-958c-9f05386a9bd4"));

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Managers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Managers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Drinks",
                columns: new[] { "Id", "Description", "DrinkCategoryId", "ImageUrl", "IsAlcoholic", "IsDeleted", "Milliliters", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("22ae7a8f-c9cc-4fc1-a2a1-dac92f36e528"), "Consists of equal parts of three main ingredients: gin, campari, and sweet vermouth", 9, "/img/drinks/negroni.jpg", true, false, 200, "Negroni", 8.00m },
                    { new Guid("2894c5f9-092c-4926-a92e-fa8ec5ca82a1"), "Sparkling Water", 1, "/img/drinks/DevinSparkling.jpg", false, false, 330, "Devin", 2.00m },
                    { new Guid("342fef96-bc35-4ed4-9320-ea056271e0e0"), "Vodka with premium quality and smooth taste", 6, "/img/drinks/Beluga.jpg", true, false, 50, "Beluga", 15.00m },
                    { new Guid("43cd6665-78ee-4127-b0b1-1c027a285c25"), "Smooth taste with subtle sweetness and a hint of almond", 6, "/img/drinks/Grey-Goose.jpg", true, false, 50, "Grey Goose", 18.00m },
                    { new Guid("5242406f-51b5-42ae-9b61-d611e62caac3"), "London Dry Gin", 7, "/img/drinks/Brokers.jpg", true, false, 50, "Brokers", 8.00m },
                    { new Guid("5bb5d7e7-0950-4a3c-b637-ea86bb513a49"), "London Dry Gin", 7, "/img/drinks/Bombay-Sapphire.jpg", true, false, 50, "Bombay Sapphire", 8.00m },
                    { new Guid("645703bd-cb2a-41d5-961d-4f16ebcbf37e"), "Espresso, Americano or Decaf", 3, "/img/drinks/coffee.jpg", false, false, 50, "Coffee", 2.00m },
                    { new Guid("6b0b9619-77ca-425e-a914-9c3df2714475"), "Red, White, or Rose", 8, "/img/drinks/Wine.jpg", true, false, 350, "Minkov Brothers Wine", 6.00m },
                    { new Guid("7a92bc0a-1c67-4476-b302-ea0e6bd58d1b"), "Smoothness, subtle sweetness, and clean finish", 6, "/img/drinks/Belvedere.jpg", true, false, 50, "Belvedere", 15.00m },
                    { new Guid("81cd5d5f-c1a2-4977-979e-41eeb78f2e0a"), "Draught beer", 4, "/img/drinks/Beer.jpg", true, false, 500, "Carlsberg", 4.50m },
                    { new Guid("8313df9a-7597-4e67-85c4-e75ccdf420b5"), "12 years aged whisky", 5, "/img/drinks/Singleton.jpg", true, false, 50, "Singleton", 15.00m },
                    { new Guid("95e5f9ab-8351-4c16-bd07-35ac4b68f62c"), "15 years aged whisky", 5, "/img/drinks/Glenfiddich.jpg", true, false, 50, "Glenfiddich", 18.00m },
                    { new Guid("af55ec9a-1b0f-404e-85f3-fc9017eb0f06"), "Scotch whisky", 5, "/img/drinks/the-sassenach.jpg", true, false, 50, "The Sassenach", 14.00m },
                    { new Guid("b1d9d70a-a7a5-45b4-b1b6-dc4a8f33fbb1"), "Herbs or Fruit flavour", 3, "/img/drinks/Tea.png", false, false, 80, "Tea", 2.00m },
                    { new Guid("bd726805-bf0a-4dac-b19d-d94105ec14d5"), "Cocoa powder by choice", 3, "/img/drinks/Cappuccino.jpg", false, false, 80, "Cappuccino", 2.60m },
                    { new Guid("d4816767-257c-44fd-bef6-3cfc42769849"), "Flavour by choice", 2, "/img/drinks/popsoda.jpg", false, false, 330, "Pop Soda", 2.50m },
                    { new Guid("d8687829-2896-4ff0-ba6a-872f31772f9e"), "Classic or sugar free", 2, "/img/drinks/cocacola.jpg", false, false, 330, "Coca Cola", 2.50m },
                    { new Guid("e52ee27b-884c-4911-97e4-1c6ac9763dc9"), "Mineral Water", 1, "/img/drinks/Devin.jpg", false, false, 330, "Devin", 1.80m },
                    { new Guid("ea6091f0-88fc-4a3f-8b0b-8f75b1144e78"), "Flavour by choice", 2, "/img/drinks/Fanta.jpg", false, false, 330, "Fanta", 2.50m },
                    { new Guid("eb5b6eae-5d12-4ba5-957d-01f4608174e6"), "Consists of aperol, prosecco, club soda, ice cubes, orange slice", 9, "/img/drinks/Aperol.Spritz.jpg", true, false, 250, "Aperol Spritz", 8.00m },
                    { new Guid("ef888509-f12f-4ac2-b011-8da99d4f8dad"), "Draught beer", 4, "/img/drinks/BeerSmall.jpg", true, false, 330, "Carlsberg", 3.00m }
                });

            migrationBuilder.InsertData(
                table: "Food",
                columns: new[] { "Id", "Description", "FoodCategoryId", "ImageUrl", "IsDeleted", "Name", "Price", "Weight" },
                values: new object[,]
                {
                    { new Guid("08160848-2273-4617-8fac-5582b4de208c"), "Spaghetti noodles topped with a meat-based sauce ragù alla bolognese", 5, "/img/food/spaghettiBolognese.jpg", false, "Spaghetti Bolognese", 12.00m, 440 },
                    { new Guid("19935328-fecf-411d-aa07-7a4148e26072"), "Romaine lettuce, croutons, parmesan cheese and a dressing consisting of olive oil, lemon juice, garlic, worcestershire sauce", 1, "/img/food/caesarsalad.jpg", false, "Caesar Salad", 12.00m, 400 },
                    { new Guid("1bd7c555-381f-4672-905e-ffa77efaa4fa"), "Traditional Austrian dish made with a thinly pounded and breaded veal cutlet, french fries, yogurt sauce", 3, "/img/food/Vienneseschnitzel.png", false, "Viennese Schnitzel", 15.00m, 500 },
                    { new Guid("34872e0a-6dcf-4229-99b0-c13f8e76af39"), "Consists of layers of coffee-soaked ladyfinger biscuits, a creamy mixture made with mascarpone cheese, flavored with a hint of liqueur, and dusted with cocoa powder on top", 7, "/img/food/tiramisu.jpg", false, "Tiramisu", 6.90m, 300 },
                    { new Guid("68c56b3f-dba0-48b1-a0d0-9ca393d9d507"), "With ketchup", 2, "/img/food/frenchfries.jpg", false, "French Fries", 6.50m, 300 },
                    { new Guid("6af823c9-6453-4be4-b791-e5185fbe083a"), "Beef burger with french fries, fresh salad, cheddar", 6, "/img/food/BeebBurger.jpg", false, "Beef Burger", 18.00m, 480 },
                    { new Guid("6d197093-80e2-4bfb-aaef-7ae8b8cf4f1c"), "Grilled chicken breasts topped with mozzarella cheese, tomato slices, fresh basil leaves, pesto", 3, "/img/food/chickencaprese.jpg", false, "Chicken Caprese", 11.50m, 400 },
                    { new Guid("761e4037-38af-464b-8dc5-3d7d29322b91"), "Mozzarella cheese, tomato sauce, spicy cured Italian sausage", 4, "/img/food/PizzaPeperoni.jpg", false, "Pizza Pepperoni", 14.99m, 550 },
                    { new Guid("89df10dc-3de5-4094-bf60-20d115da8abb"), "Spaghetti pasta, eggs, pecorino romano cheese, guanciale (cured pork cheek), black pepper", 5, "/img/food/SpaghettiCarbonara.jpg", false, "Spaghetti Carbonara", 11.00m, 440 },
                    { new Guid("8bfe4fdf-60db-49c9-9ab1-5284c928716a"), "Tomatoes, mozzarella cheese, basil leaves, olive oil, pesto", 1, "/img/food/capresesalad.jpg", false, "Caprese Salad", 12.00m, 450 },
                    { new Guid("9e7f1108-ec05-476c-b045-a109b3172a38"), "With corn flakes and ketchup", 2, "/img/food/crustedchickenstrips.jpg", false, "Crusted Chicken Strips", 10.00m, 350 },
                    { new Guid("a24c1e95-5600-4db9-950f-550875473804"), "Fresh buffalo mozzarella cheese, tomato sauce, basil leaves", 4, "/img/food/PizzaBufala.jpg", false, "Pizza Bufala", 14.99m, 550 },
                    { new Guid("b1dbe889-07fb-461f-9181-48ee594fa9bc"), "Side dish - fresh mushrooms, mushrooms sauce, french fries, carrot and broccoli", 3, "/img/food/beefsteak.jpg", false, "Beef Steak", 29.99m, 650 },
                    { new Guid("b5c74688-3fb8-4be9-9904-4923f340d8e5"), "With ketchup and yogurt sauce", 2, "/img/food/chickennugets.jpeg", false, "Chicken Nuggets", 8.00m, 350 },
                    { new Guid("ddefd4af-4405-424b-a930-0fcb459c8d7f"), "Pork burger with fresh salad and cheddar", 6, "/img/food/porkburger.jpg", false, "Pork Burger", 14.00m, 430 },
                    { new Guid("e55098c6-d8d4-4fe0-b1a2-108a9686b1f7"), "Cake with intense chocolate flavor and smooth, creamy texture", 7, "img/food/Garash.jpg", false, "Garash", 5.90m, 200 },
                    { new Guid("f419b888-b002-40e7-a742-491f9473b501"), "Chocolate souffle with vanilla ice cream", 7, "/img/food/Soufle.jpg", false, "Souffle", 6.50m, 250 }
                });
        }
    }
}
