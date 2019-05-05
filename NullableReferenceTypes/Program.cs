using Newtonsoft.Json;
using System;

namespace NullableReferenceTypes
{
    class Program
    {
        class Person
        {
            public string Fornavn { get; set; }
            public string? MellomNavn { get; set; }
            public string Etternavn { get; set; }
            public string? Fylke { get; set; } = "Oslo";
        }

        static void Main(string[] args)
        {
            var person = new Person();
            Console.WriteLine(JsonConvert.SerializeObject(person, Formatting.Indented));

            //var a = person.Fornavn.Length;
            //var b = person.MellomNavn.Length;
            //var c = person.Etternavn.Length;
            //var d = person.Fylke!.Length;

            Work(person.Fornavn);
            Work(person.MellomNavn);
            Work(person.Etternavn);
        }

        private static void Work(string input)
        {
            Console.WriteLine(input.Trim());
        }
    }
}
