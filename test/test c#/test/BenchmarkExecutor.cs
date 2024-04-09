using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

/*
 * Need to call this to execute benchmark
 *   // BenchmarkRunner.Run<BenchmarkExecutor>();
 */
namespace test
{
    [ShortRunJob]
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class BenchmarkExecutor
    {
        [Benchmark(Baseline = true)]
        public void BenchMarkExecutor()
        {
            char[] c = { 'a', 'b', 'c', 'd', 'e' };
            // program.TwoSum(c);
        }

        [Benchmark]
        public void BenchMarkExecutor2()
        {
            char[] c = { 'a', 'b', 'c', 'd', 'e' };
            // program.TwoSum(c);
        }

        [Benchmark]
        public void BenchMarkExecutor3()
        {
            char[] c = { 'a', 'b', 'c', 'd', 'e' };
            // program.TwoSum(c);
        }


    }


}
