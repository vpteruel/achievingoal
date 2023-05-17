using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Mappings.Common
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            var emptyAsNull = new ValueConverter<string, string>(value => value == "" ? null : value, value => value);

            builder.ToTable("users", "common");
            builder.HasKey(p => p.Id).HasName("id");

            builder.Property(p => p.Id).HasColumnName("id").HasColumnType("int").ValueGeneratedOnAdd();
            builder.Property(p => p.Uuid).HasColumnName("uuid").HasColumnType("uniqueidentifier").HasDefaultValue(Guid.NewGuid()).IsRequired();
            builder.Property(p => p.CreatedAt).HasColumnName("created_at").HasColumnType("datetimeoffset").HasDefaultValue(DateTimeOffset.UtcNow).IsRequired();
            builder.Property(p => p.Deleted).HasColumnName("deleted").HasColumnType("int").HasDefaultValue(0).IsRequired();

            builder.Property(p => p.GroupId).HasColumnName("id_group").HasColumnType("int").IsRequired();
            builder.Property(p => p.IsAdmin).HasColumnName("is_admin").HasColumnType("bit").HasDefaultValue(false).IsRequired();
            builder.Property(p => p.Name).HasColumnName("name").HasColumnType("varchar(200)").HasMaxLength(200).IsRequired();
            builder.Property(p => p.Email).HasColumnName("email").HasColumnType("varchar(200)").HasMaxLength(200).IsRequired();
            builder.Property(p => p.Password).HasColumnName("password").HasColumnType("varchar(100)").HasMaxLength(100);
            builder.Property(p => p.PhoneNumber).HasColumnName("phone_number").HasColumnType("varchar(50)").HasMaxLength(50).HasConversion(emptyAsNull);
            builder.Property(p => p.Birthday).HasColumnName("birthday").HasColumnType("date");

            builder.HasOne(p => p.Group);

            builder.HasQueryFilter(p => p.Deleted == 0);
        }
    }
}
