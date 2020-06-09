using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using INFNET_F.C._API.Models;

namespace INFNET_F.C._API.Data.Mapping
{
    public class EstadioMaping : IEntityTypeConfiguration<Estadio>
    {
        public void Configure(EntityTypeBuilder<Estadio> builder)
        {
            builder.HasKey(t => t.ID);
            builder.Property(t => t.NOME).HasMaxLength(100).IsRequired();
            builder.ToTable(nameof(Estadio));
        }
    }
}
