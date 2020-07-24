using IslamByAge.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IslamByAge.Infrastructure.Data.Mappings
{
    public class TopicMap : IEntityTypeConfiguration<Topic>
    {
        public void Configure(EntityTypeBuilder<Topic> builder)
        {
            builder.ToTable("Topics");
            builder.HasKey(e => e.Id);
            builder.HasOne(e => e.Category)
                .WithMany(e => e.Topics)
                .HasForeignKey(e => e.CategoryId);
            builder.Property(e => e.Body).HasColumnType("NVARCHAR(MAX)");
            builder.Property(e => e.Body).HasColumnType("NVARCHAR(MAX)");
        }
    }
}
