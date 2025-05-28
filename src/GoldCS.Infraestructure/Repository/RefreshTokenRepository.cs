using GoldCS.Domain.Interfaces;
using GoldCS.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldCS.Infraestructure.Repository
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly GoldIdentityDbContext _DbIdentity; 

        public RefreshTokenRepository(GoldIdentityDbContext DbIdentity)
        {
            _DbIdentity = DbIdentity;
        }

        public async Task<RefreshToken> ObterRefreshToken(Guid refreshToken)
        {
            var ret = await _DbIdentity.RefreshTokens.AsNoTracking().FirstOrDefaultAsync(token => token.Token == refreshToken);

            return ret != null && ret.ExpirationDate > DateTime.UtcNow ? ret : null;
        }

        public async Task SaveRefreshToken(RefreshToken refreshToken)
        {
            await _DbIdentity.RefreshTokens.AddAsync(refreshToken);
            await _DbIdentity.SaveChangesAsync();
        }
    }
}
