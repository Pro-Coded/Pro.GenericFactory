namespace Pro.GenericFactory.Tests.Entities
{
    public class EntitySingleConstructor
    {
        public int IntegerValue { get; set; }

        public EntitySingleConstructor(int integerValue)
        {
            IntegerValue = integerValue;
        }

    }
}