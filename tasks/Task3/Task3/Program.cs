using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void PrintEingespannteWerkzeuge()
        {

        }            

        static void PrintStateOfDrehmaschine(Drehmaschine drehmaschine)
        {
            Console.WriteLine("Drehmaschine 1:");
            Console.WriteLine($"Magazingroesse: {drehmaschine.MagazinGroesse}");
            for (int i = 0; i < drehmaschine.MagazinGroesse; i++)
            {
                Console.WriteLine($"Werkzeug {i}: {drehmaschine.WerkzeugMagazin[i]}");
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            var werkzeugMaschinen = new Werkzeugmaschine[]
            {
                new Drehmaschine(4),
                new Drehmaschine(6),
                new Fraesmaschine(3),
                new Fraesmaschine(5)
            };

            var drehmaschine = new Drehmaschine(4);

            // Print initial state of all machines


            PrintStateOfDrehmaschine(drehmaschine);

            // Werkzeug aufruesten
            drehmaschine.WerkzeugAufruesten(0, "Schruppmeissel");
            drehmaschine.WerkzeugAufruesten(1, "Schlichtmeissel");
            drehmaschine.WerkzeugAufruesten(2, "Gewindeschneider");

            // Print new state of Drehmaschine
            PrintStateOfDrehmaschine(drehmaschine);

            // Drehen
            drehmaschine.AktivesWerkzeug = 0;
            drehmaschine.WerkstueckBearbeiten();

            // Mit anderem Werkzeug drehen
            drehmaschine.AktivesWerkzeug = 1;
            drehmaschine.WerkstueckBearbeiten();

        }
    }
}
