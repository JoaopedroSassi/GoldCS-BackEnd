using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using src.Entities.Models;

namespace src.Data
{
    public class GoldCSDBContext : DbContext
    {
		public DbSet<Client>? Clients { get; set; }

		public GoldCSDBContext (DbContextOptions<GoldCSDBContext> options)
			: base(options)
		{

		}
    }
}