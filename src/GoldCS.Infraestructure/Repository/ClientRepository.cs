using GoldCS.Domain.Interfaces.Repository;
using GoldCS.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace GoldCS.Infraestructure.Repository
{
    public class ClientRepository : BaseCrudRepository<Client>, IClientRepository
    {
        private readonly GoldResourcesDbContext _context;

        public ClientRepository(GoldResourcesDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Client> GetClientByCpf(string cpf)
        {
            return await _context.Clients.FirstOrDefaultAsync(c => c.Cpf == cpf);
        }

        public Task<Client> GetclientById(int id)
        {
            return _context.Clients.FirstOrDefaultAsync(client => client.Id == id);
        }

        public async Task<List<Client>> GetClients()
        {
            return await _context.Clients.AsNoTracking().ToListAsync();
        }

    }
}
