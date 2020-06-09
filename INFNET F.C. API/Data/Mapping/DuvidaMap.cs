using INFNET_F.C._API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFNET_F.C._API.Data.Mapping
{
    public class DuvidaMap : IEntityTypeConfiguration<Duvida>
    {
        public void Configure(EntityTypeBuilder<Duvida> builder)
        {
            builder.HasKey(t => t.ID);
            builder.Property(t => t.Assunto).HasMaxLength(150).IsRequired();
            builder.Property(t => t.Mensagem).HasMaxLength(600).IsRequired();
            builder.HasOne(p => p.SOCIO_FK).WithMany(b => b.Duvidas).IsRequired().HasForeignKey(t=>t.IDSOCIO_FK);
            builder.ToTable(nameof(Duvida));
        }
    }
}
