using System;
using System.Collections.Generic;
using CollectionTest;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CollectionExample ex = new CollectionExample();

            // get a list by calling the client can't change version
            List<string> cantChange = ex.ClientCanNotChange(1);

            // make a change to the list just returned from the object
            cantChange.Add("E");

            // now look at the original list using the property to see if it's changed
            List<string> propertyList1 = ex.Dict[1];
            // this also highlights the weird lack of a standard ToString method
            // for generic lists in C# 
            string text1 = string.Join(" ", propertyList1);
            Console.WriteLine($"Contents of list after ClientCanNotChange: {text1}");

            // get the list by calling the can change version
            List<string> canChange = ex.ClientCanChange(2);

            // make a change to the list
            canChange.Add("I");

            // look at the list from the property
            List<string> propertyList2 = ex.Dict[2];
            string text2 = string.Join(" ", propertyList2);
            Console.WriteLine($"Contents of list after ClientCanChange: {text2}");
        }
    }
}
