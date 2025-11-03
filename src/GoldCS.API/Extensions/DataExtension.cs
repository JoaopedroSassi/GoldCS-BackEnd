using GoldCS.Infraestructure;
using Microsoft.EntityFrameworkCore;

namespace GoldCS.API.Extensions
{
	public static class DataExtension
    {
        public static async Task ManageDataAsync(IServiceProvider svcProvider)
        {
            var identityContextSvc = svcProvider.GetRequiredService<GoldIdentityDbContext>();
            await identityContextSvc.Database.MigrateAsync();

            var resourcesContextSvc = svcProvider.GetRequiredService<GoldResourcesDbContext>();
            await resourcesContextSvc.Database.MigrateAsync();
        }
    }
}