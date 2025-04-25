using GoldCS.Infraestructure;
using Microsoft.EntityFrameworkCore;


namespace GoldCS.API.Services
{
    public interface IRecycleTokenService
    {
        Task<int> RecycleRefreshTokenMoreThanOnePerUser();
    }
    public class RecycleTokenService : IRecycleTokenService
    {
        private readonly GoldIdentityDbContext _DbContext;

        public RecycleTokenService(GoldIdentityDbContext context)
        
        {
            _DbContext = context;
        }

        public async Task<int> RecycleRefreshTokenMoreThanOnePerUser()
        {
            var usersWithMoreOneToken = await _DbContext.RefreshTokens.GroupBy(user => user.UserName).Select(x => x.Key).ToListAsync();

            foreach (var user in usersWithMoreOneToken)
            {
                var moreRecentToken = await _DbContext.RefreshTokens.Where(x => x.UserName == user).OrderByDescending(x=> x.ExpirationDate).FirstOrDefaultAsync();
                var tokensToDelete = await _DbContext.RefreshTokens.Where(x => x.Token != moreRecentToken.Token).ToListAsync();
                
                if(tokensToDelete.Count > 0)
                {
                    _DbContext.RefreshTokens.RemoveRange(tokensToDelete);
                }                
            }

            return await _DbContext.SaveChangesAsync();
        }
    }
}
