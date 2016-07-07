// ReSharper disable InconsistentNaming
namespace Pro.GenericFactory.Tests
{
    #region Using Directives

    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    using Entities;

    using Infrastructure;

    using Xunit;
    using Xunit.Abstractions;

    #endregion

    [Collection("Tests")]
    public class PerformanceTests //: IClassFixture<TestsFixture>
    {
        #region Fields

        private readonly ITestOutputHelper _output;

        #endregion

        #region Constructors and Destructors

        public PerformanceTests(ITestOutputHelper output)
        {
            _output = output;

            Trace.Listeners.Clear();
            Trace.Listeners.Add(new XunitTraceListener(output));

            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);

            GC.WaitForPendingFinalizers();
        }

        #endregion

        #region Public Methods and Operators

        [Theory]
        [InlineData(1000)]
        [InlineData(10000)]
        [InlineData(100000)]
        [InlineData(1000000)]
        public void Performance_generic_factory(int iterations)
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
        public void Performance_new_instances(int iterations)
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

        #endregion
    }
}