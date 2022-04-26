using Core.Entities;
using Infrastructure.Data.Extends;
using System.Data.Entity.ModelConfiguration;

namespace Infrastructure.Data.Configurations
{
    public class ChannelConfiguration : EntityTypeConfiguration<Channel>
    {
        public ChannelConfiguration()
        {
            ToTable("Channels");

            Property(t => t.Name).IsRequired().HasMaxLength(100).IsUnique();
            Property(t => t.CreatedBy).IsRequired().HasMaxLength(128);

            HasMany(e => e.Predictions)
                .WithRequired(e => e.Channel)
                .HasForeignKey(e => e.ChannelId)
                .WillCascadeOnDelete();
        }
    }
}
