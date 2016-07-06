namespace Pro.GenericFactory.Tests.Entities
{
    using System.Collections.Generic;

    public class EntityPerformanceTest
    {
        public int IntegerValue { get; set; }

        public List<int> ListIntegers { get; set; }

        public EntityPerformanceTest(int integerValue, List<int> listIntegers )
        {
            IntegerValue = integerValue;
            ListIntegers = listIntegers;
        }
    }
}
