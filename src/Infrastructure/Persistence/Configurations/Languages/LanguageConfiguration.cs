using Domain.Languages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Languages;

public class LanguageConfiguration : IEntityTypeConfiguration<Language>
{
    public void Configure(EntityTypeBuilder<Language> builder)
    {
        builder.HasKey(x => x.Code);
        
        builder.Property(x => x.Code)
            .HasConversion(x => x.Value, x => LanguageCode.From(x))
            .HasColumnType("varchar(10)")
            .IsRequired();
        
        builder.Property(x => x.Name)
            .HasColumnType("varchar(50)")
            .IsRequired();
    }
}