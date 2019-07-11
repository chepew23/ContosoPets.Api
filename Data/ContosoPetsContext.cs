using Microsoft.EntityFramework;
using ContosoPets.Api.Models;

namespace ContosoPets.Api.Data
{
    public class ContosoPetsContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ContosoPetsContex(DbContextOptions<ContosoPetsContext> options)
            : base (options)
        {

        }
    }
}