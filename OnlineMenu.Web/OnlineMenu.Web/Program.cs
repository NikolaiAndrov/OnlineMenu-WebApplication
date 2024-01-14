namespace OnlineMenu.Web
{
	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.EntityFrameworkCore;
	using OnlineMenu.Data;
	using OnlineMenu.Data.Models;
	using OnlineMenu.Services.Interfaces;
	using OnlineMenu.Web.Infrastructure.Extensions;
	using OnlineMenu.Web.Infrastructure.ModelBinders;
	using static Common.GeneralApplicationConstants;

	public class Program
	{
		public static void Main(string[] args)
		{
			WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

			string connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

			builder.Services.AddDbContext<OnlineMenuDbContext>(options =>
				options.UseSqlServer(connectionString));

			builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
			{
				options.SignIn.RequireConfirmedAccount = builder
					.Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");

				options.Password.RequireUppercase = builder
					.Configuration.GetValue<bool>("Identity:Password:RequireUppercase");

				options.Password.RequireLowercase = builder
					.Configuration.GetValue<bool>("Identity:Password:RequireLowercase");

				options.Password.RequireNonAlphanumeric = builder
					.Configuration.GetValue<bool>("Identity:Password:RequireNonAlphanumeric");

				options.Password.RequireDigit = builder
					.Configuration.GetValue<bool>("Identity:Password:RequireDigit");

				options.Password.RequiredLength = builder
					.Configuration.GetValue<int>("Identity:Password:RequiredLength");
			})
			.AddRoles<IdentityRole<Guid>>()
			.AddEntityFrameworkStores<OnlineMenuDbContext>();

			builder.Services.ConfigureApplicationCookie(options =>
			{
				options.LoginPath = "/User/Login";
			});

			builder.Services.AddControllersWithViews()
				.AddMvcOptions(options =>
				{
					options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
					options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
				});

			builder.Services.AddApplicationServices(typeof(IFoodService));

			WebApplication app = builder.Build();

			if (app.Environment.IsDevelopment())
			{
				app.UseMigrationsEndPoint();
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error/500");
				app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthentication();
			app.UseAuthorization();

			app.SeedAdministrator(AdminEmail);

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapDefaultControllerRoute();
				endpoints.MapRazorPages();
			});

			app.Run();
		}
	}
}