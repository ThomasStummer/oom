using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Fraesmaschine : Werkzeugmaschine
    {
        // Private members
        readonly int _magazinGroesse;
        string[] _werkzeugMagazin;
        int _aktivesWerkzeug;

        // Read-only parameter
        public int MagazinGroesse => _magazinGroesse;

        // Read-only parameter
        public string[] WerkzeugMagazin => _werkzeugMagazin;

        // Read- and write-able parameter
        public int AktivesWerkzeug
        {
            get { return _aktivesWerkzeug; }
            set
            {
                ValidateMagazinPlatz(value);
                _aktivesWerkzeug = value;
            }
        }

        // Private error handling function
        void ValidateMagazinPlatz(int platz)
        {
            if (platz < 0 || platz > MagazinGroesse - 1)
            {
                throw new Exception("Magazinplatz nicht vorhanden!");
            }
        }

        // Constructor
        public Fraesmaschine(int Magazingroesse)
        {
            _magazinGroesse = Magazingroesse;
            _werkzeugMagazin = new string[_magazinGroesse];
            AktivesWerkzeug = 0;
        }

        // Public methods
        public void WerkzeugAufruesten(int MagazinPlatz, string Werkzeug)
        {
            ValidateMagazinPlatz(MagazinPlatz);
            _werkzeugMagazin[MagazinPlatz] = Werkzeug;
        }

        public void WerkstueckBearbeiten()
        {
            if (string.IsNullOrWhiteSpace(WerkzeugMagazin[AktivesWerkzeug]))
            {
                throw new Exception("Kein Fraeskopf eingespannt!");
            }
            Console.WriteLine($"Werkstück wird mit {_werkzeugMagazin[AktivesWerkzeug]} gefraest.");
        }

    }
}
