using Project.Shared.Context.AtividadeContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Project.Repository.Context.AtividadeContext.Mapping
{
    public class AtividadeMap : IEntityTypeConfiguration<Atividade>
    {
        public void Configure(EntityTypeBuilder<Atividade> builder)
        {
            builder.ToTable("Atividade");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Titulo)
                .HasColumnName("Titulo")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(300)
                .IsRequired(true);

            builder.Property(x => x.Conclusao)
                .HasColumnName("Conclusao")
                .HasColumnType("BIT")
                .IsRequired(true);

            builder.Property(x => x.DataCriacao)
                .HasColumnName("DataCriacao")
                .HasColumnType("DATETIME")
                .IsRequired(true);

            builder.Property(x => x.DataUltimaModificacao)
                .HasColumnName("DataUltimaModificacao")
                .HasColumnType("DATETIME")
                .IsRequired(false);

            builder.Property(x => x.DataExclusao)
                .HasColumnName("DataExclusao")
                .HasColumnType("DATETIME")
                .IsRequired(false);

        }
    }
}
