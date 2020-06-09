using INFNET_F.C._API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace INFNET_F.C._API.Data.Mapping
{
    public class RespostaMap : IEntityTypeConfiguration<Resposta>
    {
        public void Configure(EntityTypeBuilder<Resposta> builder)
        {
            builder.HasKey(t => t.ID);
            builder.Property(t => t.Mensagem).HasMaxLength(600).IsRequired();
            builder.HasOne(p => p.DUVIDA_FK).WithMany(b => b.Respostas).IsRequired().HasForeignKey(t=>t.IDDUVIDA_FK);
            builder.ToTable(nameof(Resposta));
        }
    }
}
