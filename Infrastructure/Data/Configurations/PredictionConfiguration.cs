using Core.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Infrastructure.Data.Configurations
{
    public class PredictionConfiguration : EntityTypeConfiguration<Prediction>
    {
        public PredictionConfiguration()
        {
            ToTable("Predictions");

            Property(t => t.Name).IsRequired().HasMaxLength(128);
        }
    }
}
