namespace Pro.GenericFactory.Tests
{
    using Infrastructure;

    using Xunit;

    [CollectionDefinition("Tests")]
    public class TestCollectionStub : ICollectionFixture<TestsFixture>
    {
    }
}
