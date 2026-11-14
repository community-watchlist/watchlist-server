using Domain.Users;
using Domain.Languages;
using Infrastructure.Persistence.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations.Users;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, x => new UserId(x));
        
        builder.Property(x => x.ClerkId)
            .HasColumnType("varchar(255)")
            .IsRequired();
        
        builder.HasIndex(x => x.ClerkId)
            .IsUnique();
        
        builder.Property(x => x.Role)
            .HasConversion(x => x.ToString(), x => UserRole.From(x))
            .HasColumnType("varchar(32)")
            .IsRequired();
        
        builder.Property(x => x.Username)
            .HasColumnType("varchar(32)")
            .IsRequired();
        
        builder.HasIndex(x => x.Username)
            .IsUnique();

        builder.Property(x => x.DisplayName)
            .HasColumnType("varchar(50)");

        builder.Property(x => x.Email)
            .HasColumnType("varchar(255)")
            .IsRequired();
        
        builder.HasIndex(x => x.Email)
            .IsUnique();

        builder.Property(x => x.Bio)
            .HasColumnType("varchar(255)");

        builder.Property(x => x.LanguageCode)
            .HasConversion(x => x.ToString(), x => LanguageCode.From(x))
            .HasColumnType("varchar(10)")
            .IsRequired();
        
        builder.HasOne(x => x.Language)
            .WithMany()
            .HasForeignKey(x => x.LanguageCode)
            .HasConstraintName("fk_users_language_code")
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.Property(x => x.CreatedAt)
            .HasConversion(new DateTimeUtcConverter())
            .HasDefaultValueSql("timezone('utc', now())")
            .IsRequired();

        builder.Property(x => x.UpdatedAt)
            .HasConversion(new DateTimeUtcConverter());
        
        builder.Property(x => x.DeletedAt)
            .HasConversion(new DateTimeUtcConverter());
        
        builder.Property(x => x.LastSeenAt)
            .HasConversion(new DateTimeUtcConverter());
        
        builder.OwnsOne(x => x.Attributes, attributesBuilder =>
        {
            attributesBuilder.ToJson("attributes");

            attributesBuilder.Property(x => x.BirthDate).HasJsonPropertyName("birth_date");
            attributesBuilder.Property(x => x.Website).HasJsonPropertyName("website");
            attributesBuilder.Property(x => x.Location).HasJsonPropertyName("location");
        });
    }
}