# My Collections Example to Show a Subtle Bug
This is some code that I created to show that some collections can still be changed if they're marked as readonly,
and to use the dotnet CLI tools to create a simple console based application with testing.
I've been reaing about IReadOnlyList and IReadOnlyDictionary and it seems like they're usually used to keep this from happening.

##Restore - Build - Run the Console Program
- Move to the directory ```src\CollectionTest``` (I know this is a bad name for the code) in the command line
- ```dotnet restore``` to install dependencies
- ```dotnet build``` to build the source files
- ```dotnet run``` to run the executable created by [Program.cs](https://github.com/jarhoads/dotnet-collections-example/blob/master/src/CollectionTest/Program.cs)

##Restore - Build - Test to run the xUnit Tests
- Move to the directory ```test\CollectionTestTests``` (See why CollectionTest is a bad name) in the command line
- ```dotnet restore``` to install dependencies
- ```dotnet build``` to build the source files
- ```dotnet test``` to run the xUnit tests in [CollectionExampleTests.cs](https://github.com/jarhoads/dotnet-collections-example/blob/master/test/CollectionTestTests/CollectionExampleTests.cs)

##The Subtle Bug
When creating a ```readonly``` dictionary that contains a generic list and it's returned in a method,
that list can be modified by a client that calls the method.

To illustrate I've created a ``` readonly Dictionary<int, List<string>>``` that has the internal list returned.
I've also created tests that show only one of them passing. 

##Tests
The tests are pretty short and probably do a better job of explaining it:
```csharp
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
```

