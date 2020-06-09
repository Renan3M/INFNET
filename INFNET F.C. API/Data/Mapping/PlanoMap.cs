using INFNET_F.C._API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFNET_F.C._API.Data.Mapping
{
    public class PlanoMap : IEntityTypeConfiguration<Plano>
    {
        public void Configure(EntityTypeBuilder<Plano> builder)
        {
            builder.HasKey(t => t.ID);
            builder.Property(t => t.Nome).HasMaxLength(150).IsRequired();
            builder.Property(t => t.Descricao).HasMaxLength(600).IsRequired();
            builder.Property(t => t.Valor).IsRequired();
            builder.Property(t => t.QtdDisponivel).IsRequired();
            builder.ToTable(nameof(Plano));
        }
    }
}
