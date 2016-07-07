namespace Pro.GenericFactory.Tests.Entities
{
    public class EntityDoubleConstructor
    {
        #region Constructors and Destructors

        public EntityDoubleConstructor(int integerValue)
        {
            IntegerValue = integerValue;
        }

        public EntityDoubleConstructor(string stringValue)
        {
            StringValue = stringValue;
        }

        #endregion

        #region Public Properties

        public int IntegerValue { get; set; }

        public string StringValue { get; set; }

        #endregion
    }
}