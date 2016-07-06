namespace Pro.GenericFactory.Tests.Entities
{
    public class EntityBaseDoubleConstructor : EntityDoubleConstructor
    {

        public EntityBaseDoubleConstructor(int integerValue) : base(integerValue)
        {
        }

        public EntityBaseDoubleConstructor(string stringValue) : base(stringValue)
        {
        }
    }
}