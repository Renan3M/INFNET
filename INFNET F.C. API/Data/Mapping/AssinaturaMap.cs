using INFNET_F.C._API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFNET_F.C._API.Data.Mapping
{
    public class AssinaturaMap : IEntityTypeConfiguration<Assinatura>
    {
        public void Configure(EntityTypeBuilder<Assinatura> builder)
        {
            builder.HasKey(t => t.ID);

            builder.Property(t => t.DataInicio).IsRequired();

            builder.Property(t => t.DataFim).IsRequired();

            builder.Property(t => t.FLG_ATIVA).IsRequired();

            builder.Property(t => t.TIPO_PAGAMENTO).IsRequired().HasDefaultValue(0);

            builder.HasOne(p => p.SOCIO_FK).WithMany(b => b.Assinaturas).IsRequired().HasForeignKey(ad => ad.IDSOCIO_FK );

            builder.HasOne(p => p.PLANO_FK).WithMany(b => b.Assinaturas).IsRequired().HasForeignKey(ad => ad.IDPLANO_FK);

            builder.ToTable(nameof(Assinatura));
        }
    }
}
