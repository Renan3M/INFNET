using INFNET_F.C._API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFNET_F.C._API.Data.Mapping
{
    public class SocioMap : IEntityTypeConfiguration<Socio>
    {
        public void Configure(EntityTypeBuilder<Socio> builder)
        {
            builder.HasKey(t => t.ID);
            builder.Property(t => t.Nome).HasMaxLength(150).IsRequired();
            builder.Property(t => t.CPF).HasMaxLength(100).IsRequired();
            builder.Property(t => t.Email).HasMaxLength(350).IsRequired();
            builder.Property(t => t.Rua).HasMaxLength(250).IsRequired();
            builder.Property(t => t.Cidade).HasMaxLength(50).IsRequired();
            builder.Property(t => t.Pais).HasMaxLength(50).IsRequired();
            builder.Property(t => t.FLG_Ativo).IsRequired().HasDefaultValue(false);
            builder.ToTable(nameof(Socio));
        }
    }
}
