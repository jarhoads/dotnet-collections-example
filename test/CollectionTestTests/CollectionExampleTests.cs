using System.Collections.Generic;
using Xunit;
using CollectionTest;

namespace CollectionTests
{
    public class CollectionExampleTests
    {

        [Fact]
        public void CanNotChangeTest()
        {
            CollectionExample ex = new CollectionExample();
            List<string> cantChange = ex.ClientCanNotChange(1);
            cantChange.Add("E");
            var expected = new List<string> {"A", "B", "C", "D"};
            var actual = ex.Dict[1];
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CanChangeTest()
        {
            CollectionExample ex = new CollectionExample();
            List<string> canChange = ex.ClientCanChange(1);
            canChange.Add("E");
            var expected = new List<string> {"A", "B", "C", "D"};
            var actual = ex.Dict[1];
            Assert.Equal(expected, actual);
        }
    }
}
