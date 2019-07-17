using Microsoft.EntityFrameworkCore;
using ContosoPets.Api.Models;

namespace ContosoPets.Api.Data
{
    public class ContosoPetsContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ContosoPetsContext(DbContextOptions<ContosoPetsContext> options)
            : base (options)
        {

        }
    }
}