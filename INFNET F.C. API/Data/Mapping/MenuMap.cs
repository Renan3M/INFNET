using INFNET_F.C._API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFNET_F.C._API.Data.Mapping
{
    public class MenuMap : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.HasKey(t => t.ID);
            builder.Property(t => t.NOME_MENU).HasMaxLength(100).IsRequired();
            builder.Property(t => t.ICONEMENU).HasMaxLength(100);
            builder.Property(t => t.ROTA_MENU).HasMaxLength(100).IsRequired();
            builder.Property(t => t.ORDEM).IsRequired();
            builder.Property(t => t.ATIVO).IsRequired();
            builder.Property(t => t.DT_CADASTRO).IsRequired();
            builder.ToTable(nameof(Menu));
        }
    }
}
