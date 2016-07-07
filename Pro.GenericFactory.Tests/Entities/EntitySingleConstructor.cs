namespace Pro.GenericFactory.Tests.Entities
{
    public class EntitySingleConstructor
    {
        #region Constructors and Destructors

        public EntitySingleConstructor(int integerValue)
        {
            IntegerValue = integerValue;
        }

        #endregion

        #region Public Properties

        public int IntegerValue { get; set; }

        #endregion
    }
}