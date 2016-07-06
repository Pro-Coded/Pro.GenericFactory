namespace Pro.GenericFactory.Tests.Infrastructure
{
    #region Using Directives

    using System;
    using System.Collections.Generic;

    using Entities;

    #endregion

    public class TestsFixture
    {
        #region Constructors and Destructors

        public TestsFixture()
        {
            GenericFactory.ClearRegistrations();

            GenericFactory.Register<EntityNoConstructor>(Constants.EntityNoConstructorKey, new Type[] { });
            GenericFactory.Register<EntitySingleConstructor>(Constants.EntitySingleConstructorKey, new[] { typeof(int) });
            GenericFactory.Register<EntityDoubleConstructor>(Constants.EntityDoubleConstructorKey1, new[] { typeof(int) });
            GenericFactory.Register<EntityDoubleConstructor>(Constants.EntityDoubleConstructorKey2, new[] { typeof(string) });
            GenericFactory.Register<EntityBaseSingleConstructor>(Constants.EntityBaseSingleConstructorKey, new[] { typeof(int) });
            GenericFactory.Register<EntityBaseDoubleConstructor>(Constants.EntityBaseDoubleConstructorKey1, new[] { typeof(int) });
            GenericFactory.Register<EntityBaseDoubleConstructor>(Constants.EntityBaseDoubleConstructorKey2, new[] { typeof(string) });
            GenericFactory.Register<EntityPerformanceTest>(Constants.EntityPerformanceTestKey, new[] { typeof(int), typeof(List<int>) });
        }

        #endregion
    }
}