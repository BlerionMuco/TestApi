using System.Collections.Generic;
using TestApi.Entities;

namespace TestUnit
{
    public class RegionsMock
    {
        public static List<Region> Data()
        {
            var regions = new List<Region>
            {
                new Region
                {
                    Id = 1,
                    RegionPrefix = "001",
                    RegionName = "Country1"
                },
                new Region
                {
                    Id = 2,
                    RegionPrefix = "0011",
                    RegionName = "Region1"
                },
                new Region
                {
                    Id = 3,
                    RegionPrefix = "0012",
                    RegionName = "Region2"
                },
                new Region
                {
                    Id = 4,
                    RegionPrefix = "0013",
                    RegionName = "Region3"
                },
                new Region
                {
                    Id = 5,
                    RegionPrefix = "0014",
                    RegionName = "Region5"
                },
                new Region
                {
                    Id = 6,
                    RegionPrefix = "0015",
                    RegionName = "Region5"
                }
            };
            return regions;
        }
    }
}