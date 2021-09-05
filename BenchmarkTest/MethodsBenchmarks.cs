using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace BenchmarkTest
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class MethodsBenchmarks
    {
        private const string phoneNumber = "00112333";

        private static readonly Methods methods = new Methods();

        [Benchmark]
        public void GetRegionsFromTestUnitProject()
        {
            methods.GetRegionsFromModel(phoneNumber);
        }
    }
}