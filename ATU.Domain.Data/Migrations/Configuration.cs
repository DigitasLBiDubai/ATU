namespace ATU.Domain.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ATU.Domain.Data.ATUContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ATU.Domain.Data.ATUContext context)
        {
            //context.Countries.AddOrUpdate(SeedData.CountrySeed());
            //context.EventCategories.AddOrUpdate(SeedData.EventCategorySeed());
            //context.VenueCategories.AddOrUpdate(SeedData.VenueCategorySeed());
        }
    }
}
