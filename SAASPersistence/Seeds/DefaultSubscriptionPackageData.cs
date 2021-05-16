using SAASDomain.Entities;
using System;
using System.Collections.Generic;

namespace SAASPersistence.Seeds
{
    public static class DefaultSubscriptionPackageData
    {
        public static List<SubscriptionPackage> SubscriptionPackageDataList()
        {
            return new List<SubscriptionPackage>
            {
                new SubscriptionPackage
                {
                    Id = new Guid("6317ce41-f6a2-48b8-833e-81c9b818cc41"),
                    Name = "EU package",
                    MonthlyPrice = 100,
                    YearlyPrice = 10000,
                    GeographicalZoneId = 1
                },
                new SubscriptionPackage
                {
                     Id = new Guid("6a3b54cd-3348-48ec-b5e9-9d24e8ae7dc7"),
                    Name = "Enterprise package",
                     MonthlyPrice = 130,
                    YearlyPrice = 13000,
                    GeographicalZoneId = 2
                },
            };
        }
    }
}
