using Dapper;
using System.Collections.Generic;
using System.Linq;
using TestApi.Context;
using TestApi.Contracts;
using TestApi.Entities;

namespace TestApi.Repository
{
    public class RegionRepository : IRegionRepository
    {
        private readonly DapperContext _context;

        public RegionRepository(DapperContext context)
        {
            _context = context;
        }

        public IEnumerable<Region> GetRegions()
        {
            var query = "SELECT * FROM Regions";

            using (var connection = _context.CreateConnection())
            {
                var regions = connection.Query<Region>(query);
                return regions.ToList();
            }
        }
    }
}