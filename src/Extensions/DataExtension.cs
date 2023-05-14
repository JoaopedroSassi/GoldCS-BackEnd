using Microsoft.EntityFrameworkCore;
using src.Data;

namespace src.Extensions
{
	public static class DataExtension
    {
        public static async Task ManageDataAsync(IServiceProvider svcProvider)
        {
            //Service: An instance of db context
            var dbContextSvc = svcProvider.GetRequiredService<GoldCSDBContext>();
            
            //Migration: This is the programmatic equivalent to Update-Database
            await dbContextSvc.Database.MigrateAsync();
        }
    }
}