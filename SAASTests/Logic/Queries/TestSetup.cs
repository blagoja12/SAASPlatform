using SAASDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SAASTests.Logic.Queries
{
    public static class TestSetup
    {
       
        public static List<User> GetUSAUserMockData()
        {

            var geographicalZone = new GeographicalZone
            {
                Id = 1,
                Name = "USA",
            };

            var region = new Region
            {
                Id = 3,
                Name = "USA",
                Vat = 0,
                GeographicalZoneId = 2,
                GeographicalZone = geographicalZone
            };

            var country = new Country
            {
                CountryCode = "az",
                CountryName = "Arizona",
                RegionId = 3,
                Region = region
            };

            var user = new User
            {
                Id = new Guid("3b6c6c8b-7d7c-4ee4-90fd-11cbb15a4b18"),
                Name = "Json Bourne",
                Email = "Json@gmail.com",
                CountryCode = "az",
                Country = country
            };

            return new List<User> { user };

        }

        public static List<User> GetEuUserMockData()
        {

            var geographicalZone = new GeographicalZone
            {
                Id = 2,
                Name = "Eurozone",
            };

            var region = new Region
            {
                Id = 2,
                Name = "EU",
                Vat = 18,
                GeographicalZoneId = 1,
                GeographicalZone = geographicalZone
            };

            var country = new Country
            {
                CountryCode = "mk",
                CountryName = "Macedonia",
                RegionId = 2,
                Region = region
            };

            var user = new User
            {
                Id = new Guid("d194bda8-1ef1-4c7b-bfff-18bb30fd5eec"),
                Name = "Blagoj Kojchev",
                Email = "blagojakojchev@gmail.com",
                CountryCode = "mk",
                Country = country
            };

            return new List<User> { user };

        }

        public static List<SubscriptionPackage> GetEuSubscriptionPackageMockData()
        {
            var subscriptionPacgages = new List<SubscriptionPackage>
            {
                new SubscriptionPackage
                {
                    Id = new Guid("6317ce41-f6a2-48b8-833e-81c9b818cc41"),
                    Name = "EU package",
                    MonthlyPrice = 100,
                    YearlyPrice = 10000,
                    GeographicalZoneId = 1,
                }
            };

            return subscriptionPacgages;
        }

        public static List<SubscriptionPackage> GetUASSubscriptionPackageMockData()
        {
            var subscriptionPacgages = new List<SubscriptionPackage>
            {
                new SubscriptionPackage
                {
                     Id = new Guid("6a3b54cd-3348-48ec-b5e9-9d24e8ae7dc7"),
                    Name = "Enterprise package",
                     MonthlyPrice = 130,
                    YearlyPrice = 13000,
                    GeographicalZoneId = 2
                }
            };

            return subscriptionPacgages;
        }

    }
}
