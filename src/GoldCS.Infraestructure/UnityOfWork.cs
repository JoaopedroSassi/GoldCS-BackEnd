using GoldCS.Domain.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace GoldCS.Infraestructure
{
    public class UnityOfWork : IUnityOfWork, IDisposable
    {
        private readonly GoldResourcesDbContext _context;
        private IDbContextTransaction dbContextTransaction { get; set; }

        public UnityOfWork(GoldResourcesDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Commit()
        {
            var ret = await _context.SaveChangesAsync() > 0;
            dbContextTransaction?.Commit();
            return ret;
        }

        public async Task IniciarTransacao()
        {
            dbContextTransaction = await _context.Database.BeginTransactionAsync();
        }

        public void Rollback()
        {
             dbContextTransaction?.Rollback();
        }
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
