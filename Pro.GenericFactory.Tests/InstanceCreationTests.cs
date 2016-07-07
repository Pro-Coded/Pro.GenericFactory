// ReSharper disable InconsistentNaming

namespace Pro.GenericFactory.Tests
{
    #region Using Directives

    using System.Diagnostics;

    using Entities;

    using Infrastructure;

    using Shouldly;

    using Xunit;
    using Xunit.Abstractions;

    #endregion

    [Collection("Tests")]
    public class InstanceCreationTests //: IClassFixture<TestsFixture>
    {
        #region Fields

        private readonly ITestOutputHelper _output;

        #endregion

        #region Constructors and Destructors

        public InstanceCreationTests(ITestOutputHelper output)
        {
            _output = output;

            Trace.Listeners.Clear();
            Trace.Listeners.Add(new XunitTraceListener(output));
        }

        #endregion

        #region Public Methods and Operators

        [Fact]
        public void Instance_created_double_constructor_int()
        {
            const int IntegerValue = 1;
            var instance = GenericFactory.CreateInstance<EntityDoubleConstructor>(Constants.EntityDoubleConstructorKey1, IntegerValue);

            instance.ShouldNotBeNull();
            instance.ShouldBeOfType(typeof(EntityDoubleConstructor));
            instance.IntegerValue.ShouldBe(IntegerValue);
            instance.StringValue.ShouldBeNullOrEmpty();
        }

        [Fact]
        public void Instance_created_double_constructor_string()
        {
            const string stringValue = "Working";
            var instance = GenericFactory.CreateInstance<EntityDoubleConstructor>(Constants.EntityDoubleConstructorKey2, stringValue);

            instance.ShouldNotBeNull();
            instance.ShouldBeOfType(typeof(EntityDoubleConstructor));
            instance.IntegerValue.ShouldBe(0);
            instance.StringValue.ShouldBe(stringValue);
        }

        [Fact]
        public void Instance_created_inherited_double_constructor_int()
        {
            const int IntegerValue = 1;
            var instance = GenericFactory.CreateInstance<EntityInheritedDoubleConstructor>(Constants.EntityInheritedDoubleConstructorKey1, IntegerValue);

            instance.ShouldNotBeNull();
            instance.ShouldBeOfType(typeof(EntityInheritedDoubleConstructor));
            instance.IntegerValue.ShouldBe(IntegerValue);
            instance.StringValue.ShouldBeNullOrEmpty();
        }

        [Fact]
        public void Instance_created_inherited_double_constructor_string()
        {
            const string stringValue = "Working";
            var instance = GenericFactory.CreateInstance<EntityInheritedDoubleConstructor>(Constants.EntityInheritedDoubleConstructorKey2, stringValue);

            instance.ShouldNotBeNull();
            instance.ShouldBeOfType(typeof(EntityInheritedDoubleConstructor));
            instance.IntegerValue.ShouldBe(0);
            instance.StringValue.ShouldBe(stringValue);
        }

        [Fact]
        public void Instance_created_no_constructor()
        {
            var instance = GenericFactory.CreateInstance<EntityNoConstructor>(Constants.EntityNoConstructorKey);

            instance.ShouldNotBeNull();
            instance.ShouldBeOfType(typeof(EntityNoConstructor));
        }

        [Fact]
        public void Instance_created_single_constructor()
        {
            const int IntegerValue = 1;
            var instance = GenericFactory.CreateInstance<EntitySingleConstructor>(Constants.EntitySingleConstructorKey, IntegerValue);

            instance.ShouldNotBeNull();
            instance.ShouldBeOfType(typeof(EntitySingleConstructor));
            instance.IntegerValue.ShouldBe(IntegerValue);
        }

        #endregion
    }
}