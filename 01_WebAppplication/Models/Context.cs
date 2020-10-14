using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppplication_01.Models
{
    public class Context : DbContext
    {
        public DbSet<Voiture> Voitures { get; set; }

        public Context(DbContextOptions<Context> op) : base(op)
        {

        }

    }
}
