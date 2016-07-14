using System;
using System.Collections.Generic;

namespace CollectionTest
{
    public class CollectionExample
    {
        private readonly Dictionary<int, List<String>> _dict;
        public Dictionary<int, List<String>> Dict
        {
            // return a copy so the client doesn't have access to the internal list
            get { return new Dictionary<int, List<String>>(_dict); }
        }

        public Dictionary<int, List<String>> MutableDict
        {
            // return the readonly dictionary
            get { return _dict; }
        }

        public CollectionExample(Dictionary<int, List<string>> dict)
        {
            _dict = dict;
        }

        public CollectionExample() 
            : this(
                new Dictionary<int, List<string>>()
                {
                    {1, new List<string> {"A", "B", "C", "D"}},
                    {2, new List<string> {"E", "F", "G", "H"}}
                }
              ) 
        { }

        public List<string> ClientCanChange(int letterList)
        {
            return Dict.ContainsKey(letterList) ? _dict[letterList] : new List<string>();
        }

        public List<string> ClientCanNotChange(int letterList)
        {
            return Dict.ContainsKey(letterList) ? new List<string>(Dict[letterList]) : new List<string>();
        }
    }
}