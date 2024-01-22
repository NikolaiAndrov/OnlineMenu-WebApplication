namespace OnlineMenu.Services.Tests
{
	using OnlineMenu.Data;
	using OnlineMenu.Data.Models;

	public static class InMemoryDatabaseSeeder
	{
		public static ApplicationUser User = null!;
		public static ApplicationUser ManagerUser = null!;
		public static Manager Manager = null!;

		public static void Seed(OnlineMenuDbContext dbContext)
		{
			User = new ApplicationUser
			{
				UserName = "niki@abv.bg",
				NormalizedUserName = "NIKI@ABV.BG",
				Email = "niki@abv.bg",
				NormalizedEmail = "NIKI@ABV.BG",
				EmailConfirmed = false,
				PasswordHash = "AQAAAAEAACcQAAAAEJYLPXHZWa4ycSOPnYdNk0ax/MPebiggeKH6XsVQ8FFw/pSAX+mL3iRJI/ewvX7ukg==",
				SecurityStamp = "W4WSBMNLOAHF245TGGRO6Z7YWOEP4FG3",
				ConcurrencyStamp = "dac3bebf-7a13-4521-b7e2-eacc3f9f3086",
				PhoneNumberConfirmed = false,
				TwoFactorEnabled = false,
				LockoutEnabled = true,
				AccessFailedCount = 0,
				FirstName = "Niki",
				LastName = "Nikov"
			};

			ManagerUser = new ApplicationUser
			{
				UserName = "piki@abv.bg",
				NormalizedUserName = "PIKI@ABV.BG",
				Email = "piki@abv.bg",
				NormalizedEmail = "PIKI@ABV.BG",
				EmailConfirmed = false,
				PasswordHash = "AQAAAAEAACcQAAAAEK5o+7gHAl0eOEeawY7S2v+lP5fTOO4Z9T62CqPZIox98VUB1l7TBjZMpBwY2t8tZg==",
				SecurityStamp = "UWC43Y6GPOOJKKMKMOFJ7ZBNLVP4YOS7",
				ConcurrencyStamp = "78a2bb41-ce2c-4117-b3a9-078abc062ee8",
				PhoneNumberConfirmed = false,
				TwoFactorEnabled = false,
				LockoutEnabled = true,
				AccessFailedCount = 0,
				FirstName = "Piki",
				LastName = "Pikova"
			};

			Manager = new Manager
			{
				PhoneNumber = "+359999999999",
				User = ManagerUser
			};

			dbContext.Users.Add(User);
			dbContext.Users.Add(ManagerUser);
			dbContext.Managers.Add(Manager);
			dbContext.SaveChanges();
		}
	}
}
