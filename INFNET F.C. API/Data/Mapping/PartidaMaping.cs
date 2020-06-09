using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using INFNET_F.C._API.Models;

namespace INFNET_F.C._API.Data.Mapping
{
    public class PartidaMaping : IEntityTypeConfiguration<Partida>
    {
        public void Configure(EntityTypeBuilder<Partida> builder)
        {
            builder.HasKey(t => t.ID);
            builder.Property(t => t.DESCR_PARTIDA).HasMaxLength(400).IsRequired();
            builder.Property(t => t.DT_CADASTRO).IsRequired();
            builder.Property(t => t.DT_PARTIDA).IsRequired();
            builder.HasOne(p => p.MANDANTE_FK).WithMany(b => b.PartidasMandante).IsRequired().HasForeignKey(ad => ad.IDMANDANTE_FK).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(p => p.VISITANTE_FK).WithMany(b => b.PartidasVisitante).IsRequired().HasForeignKey(ad => ad.IDVISITANTE_FK).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(p => p.ESTADIO_FK).WithMany(b => b.Partidas).IsRequired().HasForeignKey(ad => ad.IDESTADIO_FK);
            builder.HasOne(p => p.CAMPEONATO_FK).WithMany(b => b.Partidas).IsRequired().HasForeignKey(ad => ad.IDCAMPEONATO_FK);
            builder.ToTable(nameof(Partida));
        }
    }
}
