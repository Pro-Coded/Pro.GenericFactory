namespace Pro.GenericFactory.Tests.Infrastructure
{
    using Xunit;

    [CollectionDefinition("Instance Creation Tests")]
    public class InstanceCreationTests : ICollectionFixture<TestsFixture>
    {
    }

    [CollectionDefinition("Performance Tests")]
    public class PerformanceTests : ICollectionFixture<TestsFixture>
    {
    }
}
