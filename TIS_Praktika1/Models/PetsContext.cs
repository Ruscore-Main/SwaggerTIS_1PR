using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TIS_Praktika1.Models
{
    public class PetsContext : DbContext
    {
        public DbSet<Pet> Pets { get; set; }
        public PetsContext(DbContextOptions<PetsContext> options) : base(options)
        { }
    }
}
