using INFNET_F.C._API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFNET_F.C._API.Data.Mapping
{
    public class CobrancaMap : IEntityTypeConfiguration<Cobranca>
    {
        public void Configure(EntityTypeBuilder<Cobranca> builder)
        {
            builder.HasKey(t => t.ID);

            builder.Property(t => t.ValorTotalCobranca).IsRequired();

            builder.Property(t => t.DataValidade).IsRequired();

            builder.Property(t => t.ValorParcela).IsRequired();

            builder.Property(t => t.isRecorrente).IsRequired();

            builder.Property(t => t.FLG_PAGA).IsRequired();

            builder.HasOne(p => p.ASSINATURA_FK).WithMany(b => b.Cobrancas).IsRequired().HasForeignKey(t=> t.IDASSINATURA_FK);

            builder.ToTable(nameof(Cobranca));
        }
    }
}
