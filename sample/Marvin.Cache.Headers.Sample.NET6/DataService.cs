using System.Collections.Generic;

namespace Marvin.Cache.Headers.Sample.NET6
{
    public class DataService
    {
        public List<Person> Persons {get; set; } = new List<Person>();
    }

    public class Person {
        public int Id {get;set;}
        public string Name {get;set;}
    }
}