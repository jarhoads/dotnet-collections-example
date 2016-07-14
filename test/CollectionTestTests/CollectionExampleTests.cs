using System.Collections.Generic;
using Xunit;
using CollectionTest;

namespace CollectionTests
{
    public class CollectionExampleTests
    {
        [Fact]
        public void CanChangeDictTest()
        {
            CollectionExample ex = new CollectionExample();
            ex.MutableDict[3] = new List<string> { "J", "K" };
            var expected = new List<string>();
            // using immutable returned list 
            var actual = ex.ClientCanNotChange(3);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CanNotChangeDictTest()
        {
            CollectionExample ex = new CollectionExample();
            ex.Dict[3] = new List<string> { "J", "K" };
            var expected = new List<string>();
            // using immutable returned list
            var actual = ex.ClientCanNotChange(3);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CanNotChangeTest()
        {
            CollectionExample ex = new CollectionExample();
            List<string> cantChange = ex.ClientCanNotChange(1);
            cantChange.Add("E");
            var expected = new List<string> {"A", "B", "C", "D"};
            var actual = ex.ClientCanNotChange(1);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CanChangeTest()
        {
            CollectionExample ex = new CollectionExample();
            List<string> canChange = ex.ClientCanChange(1);
            canChange.Add("E");
            var expected = new List<string> {"A", "B", "C", "D"};
            var actual = ex.ClientCanChange(1);
            Assert.Equal(expected, actual);
        }
    }
}
