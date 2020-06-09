using INFNET_F.C._API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFNET_F.C._API.Data.Mapping
{
    public class TimeFutebolMaping : IEntityTypeConfiguration<TimeFutebol>
    {
        public void Configure(EntityTypeBuilder<TimeFutebol> builder)
        {
            builder.HasKey(t => t.ID);
            builder.Property(t => t.NOME).HasMaxLength(150).IsRequired();
            builder.Property(t => t.ESCUDO).HasMaxLength(300).IsRequired();
            builder.ToTable(nameof(TimeFutebol));
        }
    }
}
