using GoldCS.Infraestructure;
using Microsoft.EntityFrameworkCore;
using src.Data;

namespace src.Extensions
{
	public static class DataExtension
    {
        public static async Task ManageDataAsync(IServiceProvider svcProvider)
        {
            var dbContextSvc = svcProvider.GetRequiredService<GoldCSDBContext>();            
            await dbContextSvc.Database.MigrateAsync();

            var identityContextSvc = svcProvider.GetRequiredService<GoldIdentityDbContext>();
            await identityContextSvc.Database.MigrateAsync();

            var resourcesContextSvc = svcProvider.GetRequiredService<GoldResourcesDbContext>();
            await resourcesContextSvc.Database.MigrateAsync();
        }
    }
}