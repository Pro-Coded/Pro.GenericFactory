namespace Pro.GenericFactory.Tests.Entities
{
    #region Using Directives

    using System.Collections.Generic;

    #endregion

    public class EntityPerformanceTest
    {
        #region Constructors and Destructors

        public EntityPerformanceTest(int integerValue, List<int> listIntegers)
        {
            IntegerValue = integerValue;
            ListIntegers = listIntegers;
        }

        #endregion

        #region Public Properties

        public int IntegerValue { get; set; }

        public List<int> ListIntegers { get; set; }

        #endregion
    }
}