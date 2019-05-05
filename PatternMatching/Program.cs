using System;

namespace PatternMatching
{
    enum EventType
    {
        Opprettet,
        Oppdatert,
        Slettet,
        Ukjent,
    }

    interface IInterface
    {
        string InterfaceMetode();
        int InterfaceVerdi { get; }
    }

    class EksempelKlasse : IInterface
    {
        public string Fylke { get; set; } = "Oslo";

        public int InterfaceVerdi => 123;

        public string InterfaceMetode() => "Jeg implementerer interfacet!";

        // Dette lar oss bruke klassen som tuple:
        public void Deconstruct(out string fylke, out int verdi) => (fylke, verdi) = (Fylke, InterfaceVerdi);
    }

    class Program
    {
        static void Main(string[] args)
        {
            // La oss se på litt pattern matching i C#!
            var instans = new EksempelKlasse();

            Console.WriteLine(instans is IInterface);

            if (instans is IInterface interfaceInstans)
            {
                Console.WriteLine(interfaceInstans.InterfaceMetode());
            }

            // Nytt i C# 8.0 er rekursive patterns:
            if (instans is IInterface { InterfaceVerdi: 0 })
            {
                Console.WriteLine("Instansen implementerer IInterface og har verdi 0!");
            }

            // I C# 7.0 kan switch uttrykket være et hvilket som helst ikke-null uttrykk
            switch (instans)
            {
                case IAlternativtInterface alt:
                    alt.AlternativMetode();
                    break;
                case IInterface main:
                    Console.WriteLine(main.InterfaceMetode());
                    break;
                case null:
                    Console.WriteLine("'instans' er null!");
                    break;
            }

            // Også nytt i C# 7.0 er 'when' for cases
            switch (instans)
            {
                case IAlternativtInterface alt when alt.Verdi < 10:
                    break;
                case IAlternativtInterface alt when alt.Verdi >= 10:
                    Console.WriteLine("Vi har en vinner!");
                    break;
            }

            // Nytt i C# 8.0 er mer konsis syntax for switch statements:
            var beskrivelse = instans switch
            {
                // Expressions, ikke statements!
                IAlternativtInterface _   => $"Fant alternativt interface!",
                IInterface ins            => $"Fant interface med verdi {ins.InterfaceVerdi}!",
                _                         => "Fant ingen relevante interfaces!",
            };
            Console.WriteLine(beskrivelse);

            // Man kan også switche på ting inni klassen!
            var avstand = instans switch
            {
                { Fylke: "Telemark" } => "Et steinkast bort!",
                { Fylke: "Oppland" }  => "Laaaangt unna!",
                { Fylke: "Oslo" }     => "Vi er i samme fylke!",
                _                     => "Vet ikke helt hvor du er!?",
            };
            Console.WriteLine(avstand);

            // Denne kan også brukes mot tuples for eksempel:
            var spiller1 = SteinSaksPapir.Saks;
            var spiller2 = SteinSaksPapir.Stein;
            var resultat = (spiller1, spiller2) switch
            {
                (SteinSaksPapir.Stein, SteinSaksPapir.Papir) => "Stein blir dekt av papir",
                (SteinSaksPapir.Stein, SteinSaksPapir.Saks) => "Stein ødelegger saks",
                (SteinSaksPapir.Papir, SteinSaksPapir.Stein) => "Papir dekker stein",
                (SteinSaksPapir.Papir, SteinSaksPapir.Saks) => "Papir blir kuttet av saks",
                (SteinSaksPapir.Saks, SteinSaksPapir.Stein) => "Saks blir ødelagt av stein",
                (SteinSaksPapir.Saks, SteinSaksPapir.Papir) => "Saks kutter papir",
                (_, _) => "Uavgjort",
            };
            Console.WriteLine(resultat);

            // Man kan også bruke typer direkte vha deconstruction:
            var kalkulertAvstand = instans switch
            {
                ("Telemark", var verdi) => verdi * 2,
                ("Oppland", var verdi)  => verdi * 3,
                ("Oslo", var verdi)     => verdi * 1,
                var (fylke, verdi)      => fylke.Length * verdi,
            };
            Console.WriteLine($"Avstand: {kalkulertAvstand}");
        }
    }

    interface IAlternativtInterface
    {
        void AlternativMetode();
        int Verdi { get; }
    }

    enum SteinSaksPapir
    {
        Stein,
        Saks,
        Papir,
    }
}
