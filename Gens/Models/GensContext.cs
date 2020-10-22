using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gens.Models
{
    public class GensContext : DbContext
    {
        public DbSet<Personne> Gens { get; set; }
        public GensContext(DbContextOptions<GensContext> o) : base(o)
        {

        }
    }
}
