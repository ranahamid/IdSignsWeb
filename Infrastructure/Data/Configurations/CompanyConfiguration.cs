using Core.Entities;
using Infrastructure.Data.Extends;
using System.Data.Entity.ModelConfiguration;

namespace Infrastructure.Data.Configurations
{
    public class CompanyConfiguration : EntityTypeConfiguration<Company>
    {
        public CompanyConfiguration()
        {
            ToTable("Companies");

            Property(t => t.Name).IsRequired().HasMaxLength(100).IsUnique();
            Property(t => t.Address).IsRequired().HasMaxLength(512);
            Property(t => t.CreatedBy).IsRequired().HasMaxLength(128);

            HasMany(e => e.Channels)
                .WithRequired(e => e.Company)
                .HasForeignKey(e => e.CompanyId)
                .WillCascadeOnDelete();

            HasMany(e => e.Users)
                .WithOptional(x => x.Company)
                .HasForeignKey(e => e.CompanyId)
                .WillCascadeOnDelete();
        }
    }
}
