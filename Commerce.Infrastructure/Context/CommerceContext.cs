using Commerce.Domain.Entitie;
using Microsoft.EntityFrameworkCore;

namespace Commerce.Infrastructure.Context
{
    public class CommerceContext(DbContextOptions<CommerceContext> options) : DbContext(options)
    {
        public DbSet<Produto> Produtos { get; set; }
    }
}
