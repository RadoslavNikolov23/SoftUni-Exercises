namespace CinemaApp
{
    using Data;
    using Data.Models;
    using Data.Seeding;
    using Data.Seeding.Interfaces;
    using Data.Utilities;
    using Data.Utilities.Interfaces;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("CinemaDbConnection") ??
                                   throw new InvalidOperationException(
                                       "Connection string 'DefaultConnection' not found.");
           
            builder.Services.AddDbContext<CinemaDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddScoped<IValidator, EntityValidator>();
            builder.Services.AddSingleton<IXmlHelper, XmlHelper>();
            builder.Services.AddScoped<IDbSeeder, ApplicationDbContextSeeder>();

            // TODO: Introduce extension method for run-time detection and registration of seeders
            builder.Services.AddScoped<CinemaMovieSeeder>();
            builder.Services.AddScoped<IdentitySeeder>();
            builder.Services.AddScoped<MoviesSeeder>();
            builder.Services.AddScoped<TicketSeeder>();
            builder.Services.AddScoped<WatchlistSeeder>();

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services
                .AddIdentity<ApplicationUser, IdentityRole<Guid>>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;

                    options.Password.RequireDigit = true;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequiredLength = 3;
                })
                .AddRoles<IdentityRole<Guid>>()
                .AddEntityFrameworkStores<CinemaDbContext>();
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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

            if (app.Environment.IsDevelopment())
            {
                using IServiceScope scope = app.Services.CreateScope();
                IServiceProvider services = scope.ServiceProvider;

                IDbSeeder dataProcessor = services.GetRequiredService<IDbSeeder>();
                dataProcessor.SeedData()
                    .GetAwaiter()
                    .GetResult();
            }

            app.Run();

        }
    }
}