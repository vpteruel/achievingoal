using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings.Common
{
    public class GroupMap : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable("groups", "common");
            builder.HasKey(p => p.Id).HasName("id");

            builder.Property(p => p.Id).HasColumnName("id").HasColumnType("int").ValueGeneratedOnAdd();
            builder.Property(p => p.Uuid).HasColumnName("uuid").HasColumnType("uniqueidentifier").HasDefaultValue(Guid.NewGuid()).IsRequired();
            builder.Property(p => p.CreatedAt).HasColumnName("created_at").HasColumnType("datetimeoffset").HasDefaultValue(DateTimeOffset.UtcNow).IsRequired();
            builder.Property(p => p.Deleted).HasColumnName("deleted").HasColumnType("int").HasDefaultValue(0).IsRequired();

            builder.Property(p => p.Name).HasColumnName("name").HasColumnType("varchar(200)").HasMaxLength(200).IsRequired();
            builder.Property(p => p.Alias).HasColumnName("alias").HasColumnType("varchar(32)").HasMaxLength(32).IsRequired();

            builder.HasMany(p => p.Users).WithOne(p => p.Group).HasForeignKey(p => p.GroupId);

            builder.HasQueryFilter(p => p.Deleted == 0);
        }
    }
}
