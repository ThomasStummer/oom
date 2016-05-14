using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Drehmaschine : Werkzeugmaschine
    {
        // Private members
        int _id;
        readonly int _magazinGroesse;
        string [] _werkzeugMagazin;        
        int _aktivesWerkzeug;

        // Read-only
        public int ID() => _id;

        // Read-only 
        public int MagazinGroesse() => _magazinGroesse;

        // Read-only
        public string WerkzeugMagazin(int MagazinPlatz) => _werkzeugMagazin[MagazinPlatz];

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
            if (platz < 0 || platz > MagazinGroesse() - 1)
            {
                throw new Exception("Magazinplatz nicht vorhanden!");
            }
        }

        // Constructor
        public Drehmaschine(int Id, int Magazingroesse)
        {
            _id = Id;
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
            if(string.IsNullOrWhiteSpace(WerkzeugMagazin(AktivesWerkzeug)))
            { 
                throw new Exception("Kein Meißel eingespannt!");
            }
            Console.WriteLine($"Werkstück wird mit {_werkzeugMagazin[AktivesWerkzeug]} gedreht.");
        }
        
    }
}
