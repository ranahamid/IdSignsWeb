namespace Infrastructure.Data.Migrations
{
    using Core.Entities.Identity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Infrastructure.Data.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            MigrationsDirectory = @"Data\Migrations";
        }

        protected override void Seed(Infrastructure.Data.AppDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //context.Users.AddOrUpdate(x => x.Id, new ApplicationUser { UserName = "sojib", Email = "sojib352@gmail.com", CreatedAt = DateTime.Now });
        }
    }
}
