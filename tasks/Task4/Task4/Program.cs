using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void WerkstueckBearbeiten(Werkzeugmaschine werkzeugmaschine)
        {
            Console.WriteLine(werkzeugmaschine.WerkstueckBearbeiten());
        }

        static void StdAufruestungDrehmaschine(Drehmaschine drehmaschine)
        {
            string[] werkzeuge = { "Schruppmeissel", "Schlichtmeissel", "Gewindeschneider", "Abstecher" };
            for (int i = 0; i < drehmaschine.GetMagazinGroesse(); i++)
                drehmaschine.WerkzeugAufruesten(i, werkzeuge[i]);
        }

        static void StdAufruestungFraesmaschine(Fraesmaschine fraesmaschine)
        {
            string[] werkzeuge = { "SchruppFraeskopf", "Schlichtfraeskopf", "Bohrer", "Gewindeschneider" };
            for (int i = 0; i < fraesmaschine.GetMagazinGroesse(); i++)
                fraesmaschine.WerkzeugAufruesten(i, werkzeuge[i]);
        }

        static void WerkzeugmaschineAufruesten(Werkzeugmaschine werkzeugmaschine)
        {
            if (werkzeugmaschine is Drehmaschine)
                StdAufruestungDrehmaschine((Drehmaschine)werkzeugmaschine);
            else if (werkzeugmaschine is Fraesmaschine)
                StdAufruestungFraesmaschine((Fraesmaschine)werkzeugmaschine);
        }

        static void PrintStateOfWerkzeugmaschine(Werkzeugmaschine werkzeugmaschine)
        {
            Console.WriteLine($"{werkzeugmaschine.GetType()} {werkzeugmaschine.GetID()}:");
            Console.WriteLine($"Magazingroesse: {werkzeugmaschine.GetMagazinGroesse()}");
            for (int i = 0; i < werkzeugmaschine.GetMagazinGroesse(); i++)
                Console.WriteLine($"Werkzeug {i}: {werkzeugmaschine.GetWerkzeugMagazin(i)}");
            Console.WriteLine();
        }

        static void ExecuteActionOnAllWerkzeugmaschinen(Werkzeugmaschine[] werkzeugmaschinen, Action<Werkzeugmaschine> action)
        {
            foreach (Werkzeugmaschine werkzeugmaschine in werkzeugmaschinen)
                action(werkzeugmaschine);
        }

        static void Main(string[] args)
        {
            var werkzeugMaschinen = new Werkzeugmaschine[]
            {
                new Drehmaschine(2, 4),
                new Fraesmaschine(4, 4)
            };

            // Print initial state of all machines
            Console.WriteLine("Print inital state of machines\n");
            ExecuteActionOnAllWerkzeugmaschinen(werkzeugMaschinen, PrintStateOfWerkzeugmaschine);

            // Werkzeug aufruesten
            Console.WriteLine("Add tools to machines\n");
            ExecuteActionOnAllWerkzeugmaschinen(werkzeugMaschinen, WerkzeugmaschineAufruesten);

            // Print new state of machines
            Console.WriteLine("Print new state of machines\n");
            ExecuteActionOnAllWerkzeugmaschinen(werkzeugMaschinen, PrintStateOfWerkzeugmaschine);

            // Drehen und Fraesen
            Console.WriteLine("Let the work beginn...\n");
            ExecuteActionOnAllWerkzeugmaschinen(werkzeugMaschinen, WerkstueckBearbeiten);
        }
    }
}
