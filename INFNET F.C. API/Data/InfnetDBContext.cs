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

        public DbSet<Plano> Planos { get; set; }

        public DbSet<Assinatura> Assinaturas { get; set; }

        public DbSet<Cobranca> Cobrancas { get; set; }

        public DbSet<Duvida> Duvidas { get; set; }

        public DbSet<Resposta> Respostas { get; set; }

        public DbSet<Menu> Menus { get; set; }

        public DbSet<Partida> Partidas { get; set; }
        public DbSet<TimeFutebol> TimesFutebol { get; set; }
        public DbSet<Estadio> Estadios { get; set; }
        public DbSet<Campeonato> Campeonatos { get; set; }

        public DbSet<AssinaturaPartida> AssinaturaPartida { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration(new SocioMap());
            modelBuilder.ApplyConfiguration(new PlanoMap());
            modelBuilder.ApplyConfiguration(new AssinaturaMap());
            modelBuilder.ApplyConfiguration(new CobrancaMap());
            modelBuilder.ApplyConfiguration(new DuvidaMap());
            modelBuilder.ApplyConfiguration(new RespostaMap());
            modelBuilder.ApplyConfiguration(new MenuMap());
            modelBuilder.ApplyConfiguration(new PartidaMaping());
            modelBuilder.ApplyConfiguration(new TimeFutebolMaping());
            modelBuilder.ApplyConfiguration(new EstadioMaping());
            modelBuilder.ApplyConfiguration(new CampeonatoMaping());

            modelBuilder.Entity<AssinaturaPartida>()
            .HasKey(bc => new { bc.AssinaturaId, bc.PartidaId });
            modelBuilder.Entity<AssinaturaPartida>()
                .HasOne(bc => bc.Assinatura)
                .WithMany(b => b.AssinaturaPartida)
                .HasForeignKey(bc => bc.AssinaturaId);
            modelBuilder.Entity<AssinaturaPartida>()
                .HasOne(bc => bc.Partida)
                .WithMany(c => c.AssinaturaPartida)
                .HasForeignKey(bc => bc.PartidaId);



        }
    }
}