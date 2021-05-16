using Microsoft.EntityFrameworkCore;
using SAASDomain.Entities;

namespace SAASPersistence.Seeds
{
    public static class ContextSeed
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            CreateRegionData(modelBuilder);
            CreateUserData(modelBuilder);
            CreateCountryData(modelBuilder);
            CreateSubscriptionPackageData(modelBuilder);
            CreateGraphicalZoneData(modelBuilder);
        }

        private static void CreateGraphicalZoneData(ModelBuilder modelBuilder)
        {
            var geographicalZon = DefaultGeographicalZoneData.RegionDataList();
            modelBuilder.Entity<GeographicalZone>().HasData(geographicalZon);
        }

        private static void CreateRegionData(ModelBuilder modelBuilder)
        {
            var regionData = DefaultRegionData.RegionDataList();
            modelBuilder.Entity<Region>().HasData(regionData);
        }

        private static void CreateUserData(ModelBuilder modelBuilder)
        {
            var userData = DefaultUserData.UserDataList();
            modelBuilder.Entity<User>().HasData(userData);
        }

        private static void CreateCountryData(ModelBuilder modelBuilder)
        {
            var countryData = DefaultCountryData.CountryDataList();
            modelBuilder.Entity<Country>().HasData(countryData);
        }

        private static void CreateSubscriptionPackageData(ModelBuilder modelBuilder)
        {
            var subscriptionPackageData = DefaultSubscriptionPackageData.SubscriptionPackageDataList();
            modelBuilder.Entity<SubscriptionPackage>().HasData(subscriptionPackageData);
        }
    }
}
