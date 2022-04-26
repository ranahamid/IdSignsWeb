using Core.Entities;
using Core.Entities.Identity;
using Infrastructure.Data.Configurations;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext() : base("AppConnectionString", throwIfV1Schema: false)
        {
        }

        public static AppDbContext Create() => new AppDbContext();

        public virtual Channel ChannelSet { get; set; }
        public virtual Company CompanySet { get; set; }
        public virtual Prediction PredictionSet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new CompanyConfiguration());
            modelBuilder.Configurations.Add(new ChannelConfiguration());
            modelBuilder.Configurations.Add(new PredictionConfiguration());
        }
    }
}
