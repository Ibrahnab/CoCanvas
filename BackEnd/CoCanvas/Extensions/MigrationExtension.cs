using CoCanvas.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;

namespace CoCanvas.Api.Extensions
{
    public static class MigrationExtension
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();
            using CCDbContext context = scope.ServiceProvider.GetRequiredService<CCDbContext>();

            context.Database.Migrate();
        }
    }
}
