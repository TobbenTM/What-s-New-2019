using System;

namespace SpansIndicesAndRanges
{
    class Program
    {
        static void Main(string[] args)
        {
            // Nytt i C# 7.2 er spans:
            var array = new int[] { 1, 2, 3, 4, 5 };
            var slice = new Span<int>(array, 1, 3);
            // Alt:
            var slice2 = array.AsSpan().Slice(1, 3);
            
            foreach (var num in slice)
            {
                Console.Write($"{num}\t");
            }
            Console.Write('\n');

            slice[0] *= 2;

            foreach (var num in array)
            {
                Console.Write($"{num}\t");
            }
            Console.Write('\n');

            // Nytt i C# 8.0 er nye måter å definere subset:
            // (fungerer for arrays, Span<T> og ReadOnlySpan<T>)
            var subset = array[0..^1]; // Fra 0 til og med nest siste
            foreach (var num in subset)
            {
                Console.Write($"{num}\t");
            }
            Console.Write('\n');

            var siste = array[^1]; // Eller 1 fra siste
            Console.WriteLine(siste);

            var alle = array[..];
            var alleUnntattFørste = array[1..];
        }
    }
}
