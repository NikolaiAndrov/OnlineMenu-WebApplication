namespace OnlineMenu.WebApi
{
	using Microsoft.EntityFrameworkCore;
	using OnlineMenu.Data;
	using OnlineMenu.Services;
	using OnlineMenu.Services.Interfaces;

	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			string connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
				?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

			builder.Services.AddDbContext<OnlineMenuDbContext>(options =>
				options.UseSqlServer(connectionString));

			builder.Services.AddScoped<IFoodService, FoodService>();
			builder.Services.AddScoped<IDrinkService, DrinkService>();

			builder.Services.AddControllers();

			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.AddCors(setup =>
			{
				setup.AddPolicy("OnlineMenu", policyBuilder =>
				{
					policyBuilder.WithOrigins("https://localhost:7070")
					.AllowAnyHeader()
					.AllowAnyMethod();
				});
			});

			var app = builder.Build();

			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.UseCors("OnlineMenu");

			app.Run();
		}
	}
}
