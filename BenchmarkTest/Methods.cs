using System.Collections.Generic;

namespace BenchmarkTest
{
    public class Methods
    {
        public List<Region> GetRegionsFromModel(string phone)
        {
            string regionPrefix = phone.Substring(0, 4);

            var regions = RegionsMock.Data();

            List<Region> response = new List<Region>();

            foreach (var region in regions)
            {
                if (region.RegionPrefix == regionPrefix)
                {
                    response.Add(new Region
                    {
                        Id = region.Id,
                        RegionPrefix = region.RegionPrefix,
                        RegionName = region.RegionName
                    });
                }
            }
            return response;
        }
    }
}