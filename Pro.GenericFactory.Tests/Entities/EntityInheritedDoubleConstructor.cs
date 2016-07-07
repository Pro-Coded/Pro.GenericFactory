namespace Pro.GenericFactory.Tests.Entities
{
    public class EntityInheritedDoubleConstructor : EntityDoubleConstructor
    {
        #region Constructors and Destructors

        public EntityInheritedDoubleConstructor(int integerValue)
            : base(integerValue)
        {
        }

        public EntityInheritedDoubleConstructor(string stringValue)
            : base(stringValue)
        {
        }

        #endregion
    }
}