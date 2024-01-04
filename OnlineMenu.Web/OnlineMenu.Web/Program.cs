namespace OnlineMenu.Web
{
    using Microsoft.EntityFrameworkCore;
    using OnlineMenu.Data;
    using OnlineMenu.Data.Models;

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
            .AddEntityFrameworkStores<OnlineMenuDbContext>();

            builder.Services.AddControllersWithViews();

            WebApplication app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}