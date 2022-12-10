using EvoSystemWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EvoSystemWebAPI.Data.Map
{
    public class DepartamentoMap : IEntityTypeConfiguration<DepartamentoModel>
    {
        public void Configure(EntityTypeBuilder<DepartamentoModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Sigla).IsRequired().HasMaxLength(3);
        }
    }
}

