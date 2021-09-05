using System.Collections.Generic;
using TestApi.Entities;

namespace TestApi.Contracts
{
    public interface IRegionRepository
    {
        public IEnumerable<Region> GetRegions();
    }
}