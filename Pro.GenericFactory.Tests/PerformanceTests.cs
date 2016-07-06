using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pro.GenericFactory.Tests
{
    using System.Collections.Generic;
    using System.Diagnostics;

    using Entities;
    using Infrastructure;

    using Xunit;
    using Xunit.Abstractions;

    public class PerformanceTests : IClassFixture<TestsFixture>
    {
        private readonly ITestOutputHelper _output;


        public PerformanceTests(ITestOutputHelper output)
        {
            _output = output;

            Trace.Listeners.Clear();
            Trace.Listeners.Add(new XunitTraceListener(output));



            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
        }

        [Theory]
        [InlineData(1000)]
        [InlineData(10000)]
        [InlineData(100000)]
        [InlineData(1000000)]
        public void Perf_generic_factory(int iterations)
        {

            var list = new List<int>();

            var watch = Stopwatch.StartNew();

            for (var i = 0; i < iterations; i++)
            {
                var instance = GenericFactory.CreateInstance<EntityPerformanceTest>(Constants.EntityPerformanceTestKey, 1, list);
            }

            watch.Stop();

            _output.WriteLine(watch.Elapsed.ToString());
        }

        [Theory]
        [InlineData(1000)]
        [InlineData(10000)]
        [InlineData(100000)]
        [InlineData(1000000)]
        public void Perf_new_instances(int iterations)
        {
            var list = new List<int>();

            var watch = Stopwatch.StartNew();

            for (var i = 0; i < iterations; i++)
            {
                var instance = new EntityPerformanceTest(1, list);
            }

            watch.Stop();

            _output.WriteLine(watch.Elapsed.ToString());
        }
    }
}
