using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameWorkRelationships.Models
{
    public class Context : DbContext
    {
        public DbSet<Personne> Gens { get; set; }

        public Context(DbContextOptions<Context> dbContextOptions) :base (dbContextOptions)
        {

        }


    }
}
