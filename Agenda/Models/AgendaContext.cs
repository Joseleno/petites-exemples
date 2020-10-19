using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda.Models
{
    public class AgendaContext : DbContext
    {
        public DbSet<Tache> Tache { get; set; }
        public AgendaContext(DbContextOptions<AgendaContext> o) : base(o)
        {

        }
    }
}
