using Microsoft.EntityFrameworkCore;

namespace Sondage.Models
{
    public class SondageContext : DbContext
    {
        public DbSet<Cryptocurrency> Cryptocurrency { get; set; }
        public SondageContext(DbContextOptions<SondageContext> o) : base(o)
        {

        }
    }
}
