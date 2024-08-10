using GestionImmo.Repo;
using Microsoft.EntityFrameworkCore;

namespace GestionImmo;

public static class WebApplicationBuilderExtension
{
    public static void ConfigureDbContext(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<DatabaseContext>(options =>
        {
            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;
            options.UseSqlServer(connectionString);
        });
    }

    public static void ConfigureServices(this WebApplicationBuilder builder)
    {
        //builder.Services.AddTransient<ITokenService, TokenService>();
    }
}