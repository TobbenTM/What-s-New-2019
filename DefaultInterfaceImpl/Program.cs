using System;

namespace DefaultInterfaceImpl
{
    class Program
    {
        interface IInterface
        {
            void Metode() => Console.WriteLine("Default impl!");
        }

        class Klasse : IInterface
        {
        }

        static void Main(string[] args)
        {
            // Dette funker ikke:
            //Klasse klasse = new Klasse();

            // Men concrete Klasse() har en impl av Metode()
            IInterface klasse = new Klasse();
            klasse.Metode();
        }
    }
}
