using Microsoft.EntityFrameworkCore;

namespace GestionCV.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
    }
}