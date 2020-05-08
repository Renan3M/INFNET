using INFNET_F.C._API.Data.Mapping;
using INFNET_F.C._API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFNET_F.C._API.Data
{
    public class InfnetDBContext : DbContext
    {
        public InfnetDBContext(DbContextOptions<InfnetDBContext> options) 
            : base(options) { }
        

        public DbSet<Socio> Socios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration(new SocioMap());
        }
    }
}
