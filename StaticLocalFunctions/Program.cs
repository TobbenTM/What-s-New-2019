using System;

namespace StaticLocalFunctions
{
    class Program
    {
        static void Main(string[] args)
        {
            var i = 0;
            LokalFunksjon();

            // TODO: Denne burde vært static?
            void LokalFunksjon() => i += 1;

            Console.WriteLine($"i: {i}");
        }
    }
}
