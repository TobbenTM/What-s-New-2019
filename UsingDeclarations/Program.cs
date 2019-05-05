using System;

namespace UsingDeclarations
{
    class DisposableClass : IDisposable
    {
        public DisposableClass()
        {
            Console.WriteLine("Oppretter disposable klasse!");
        }

        public void Work()
        {
            Console.WriteLine("Working..");
        }

        public void Dispose()
        {
            Console.WriteLine("Disposable klasse blir disposed!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Tidligere måtte man bruke using med eksplisitte blokker:
            using (var disposable = new DisposableClass())
            {
                disposable.Work();
            }

            // Nå vil using returnere en instans som blir disposet på slutten av scopet!
            using var localDisposable = new DisposableClass();
            Console.WriteLine("Vi kan nå bruke den disposable klassen:");
            localDisposable.Work();
            // Blir automatisk disposed på slutten av scopet
        }
    }
}
