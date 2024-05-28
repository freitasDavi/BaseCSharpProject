using CashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashFlow.Infrastructure.DataAccess.Maps
{
    internal class ValoresPecasMap : IEntityTypeConfiguration<ValorPeca>
    {
        public void Configure(EntityTypeBuilder<ValorPeca> builder)
        {
            builder.ToTable("valorpeca");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("CodigoValoresPeca")
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Nome);

            builder.Property(x => x.Valor);

            builder.Property(x => x.CodigoPeca);
        }
    }
}
