namespace Pro.GenericFactory.Tests.Entities
{
    public class EntityDoubleConstructor
    {
        public string StringValue { get; set; }

        public int IntegerValue { get; set; }

        public EntityDoubleConstructor(int integerValue)
        {
            IntegerValue = integerValue;
        }

        public EntityDoubleConstructor(string stringValue) 
        {
            StringValue = stringValue;
        }
    }
}