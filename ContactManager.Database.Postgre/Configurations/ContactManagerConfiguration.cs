using ContactManager.Database.Postgre.DalEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContactManager.Database.Postgre.Configurations;

public class ContactManagerConfiguration : IEntityTypeConfiguration<ContactManagerDal>
{
    public void Configure(EntityTypeBuilder<ContactManagerDal> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.Email)
            .IsUnique();
        
        builder.Property(x => x.Id)
            .HasColumnType("uuid")
            .HasColumnName("id");
        
        builder.Property(x => x.Salution)
            .HasColumnType("text")
            .HasColumnName("salution")
            .IsRequired();

        builder.Property(x => x.FirstName)
            .HasColumnType("text")
            .HasColumnName("first_name")
            .IsRequired();
        
        builder.Property(x => x.LastName)
            .HasColumnType("text")
            .HasColumnName("last_name")
            .IsRequired();

        builder.Property(x => x.DisplayName)
            .HasColumnType("text")
            .HasColumnName("display_name");

        builder.Property(x => x.BirthDate)
            .HasColumnType("date")
            .HasColumnName("birth_date");

        builder.Property(x => x.CreationTimestamp)
            .HasColumnType("timestamp with time zone")
            .HasColumnName("creation_timestamp")
            .IsRequired();

        builder.Property(x => x.LastChangeTimestamp)
            .HasColumnType("timestamp with time zone")
            .HasColumnName("last_change_timestamp");
        
        builder.Property(x => x.Email)
            .HasColumnType("text")
            .HasColumnName("email")
            .IsRequired();
        
        builder.Property(x => x.PhoneNumber)
            .HasColumnType("text")
            .HasColumnName("phone_number")
            .HasMaxLength(50);
    }
}