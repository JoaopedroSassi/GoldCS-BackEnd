using GoldCS.Domain.Interfaces.Repository;
using GoldCS.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace GoldCS.Infraestructure.Repository
{
    public class AdressRepository : BaseCrudRepository<Adress>, IAdressRepository
    {
        private readonly GoldResourcesDbContext _context;
        public AdressRepository(GoldResourcesDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Adress> FindByCepAndClientId(string cep, int clientId)
        {
            return await _context.Adresses.FirstOrDefaultAsync(x => x.CEP == cep && x.ClientId == clientId);
        }
    }
}
