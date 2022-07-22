using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiifinal.Data
{
    public class PortDbContext : DbContext
    {
        public PortDbContext(DbContextOptions<PortDbContext> options) : base(options)
        {

        }
        public DbSet<PortSlots> Pslots { get; set; }
        public DbSet<PortUsers> Pusers { get; set; }
    }
}
