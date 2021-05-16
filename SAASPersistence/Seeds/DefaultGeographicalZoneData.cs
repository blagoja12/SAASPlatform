using SAASDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SAASPersistence.Seeds
{
    public class DefaultGeographicalZoneData
    {
        public static List<GeographicalZone> RegionDataList()
        {
            return new List<GeographicalZone>
            {
                 new GeographicalZone
                 {
                     Id = 1,
                     Name = "USA"
                 },
                 new GeographicalZone
                 {
                     Id = 2,
                     Name = "Eurozone"
                 }
            };
        }
    }
}
