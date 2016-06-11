using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    class StaticDemoClass
    {
        public static void WerkstueckBearbeiten(IWerkzeugmaschine werkzeugmaschine)
        {
            Console.WriteLine(werkzeugmaschine.WerkstueckBearbeiten());
        }

        private static void StdAufruestungDrehmaschine(Drehmaschine drehmaschine)
        {
            string[] werkzeuge = { "Schruppmeissel", "Schlichtmeissel", "Gewindeschneider", "Abstecher" };
            for (int i = 0; i < drehmaschine.MagazinGroesse; i++)
                drehmaschine.WerkzeugAufruesten(i, werkzeuge[i]);
        }

        private static void StdAufruestungFraesmaschine(Fraesmaschine fraesmaschine)
        {
            string[] werkzeuge = { "SchruppFraeskopf", "Schlichtfraeskopf", "Bohrer", "Gewindeschneider" };
            for (int i = 0; i < fraesmaschine.MagazinGroesse; i++)
                fraesmaschine.WerkzeugAufruesten(i, werkzeuge[i]);
        }

        public static void WerkzeugmaschineAufruesten(IWerkzeugmaschine werkzeugmaschine)
        {
            if (werkzeugmaschine is Drehmaschine)
                StdAufruestungDrehmaschine((Drehmaschine)werkzeugmaschine);
            else if (werkzeugmaschine is Fraesmaschine)
                StdAufruestungFraesmaschine((Fraesmaschine)werkzeugmaschine);
        }

        public static void PrintStateOfWerkzeugmaschine(IWerkzeugmaschine werkzeugmaschine)
        {
            Console.WriteLine($"{werkzeugmaschine.GetType()} {werkzeugmaschine.ID}:");
            Console.WriteLine($"Magazingroesse: {werkzeugmaschine.MagazinGroesse}");
            for (int i = 0; i < werkzeugmaschine.MagazinGroesse; i++)
                Console.WriteLine($"Werkzeug {i}: {werkzeugmaschine.WerkzeugMagazin[i]}");
            Console.WriteLine();
        }

        public static void ExecuteActionOnAllWerkzeugmaschinen(IWerkzeugmaschine[] werkzeugmaschinen, Action<IWerkzeugmaschine> action)
        {
            foreach (IWerkzeugmaschine werkzeugmaschine in werkzeugmaschinen)
                action(werkzeugmaschine);
        }
    }
}
