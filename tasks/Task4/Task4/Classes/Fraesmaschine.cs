using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Task4
{
    class Fraesmaschine : Werkzeugmaschine
    {
        // Private members
        int _id;
        readonly int _magazinGroesse;
        List<string> _werkzeugMagazin;
        int _aktivesWerkzeug;

        // Read-only attribute
        public int ID => _id;

        // Read-only attribute 
        public int MagazinGroesse => _magazinGroesse;

        // Read-only attribute
        public List<string> WerkzeugMagazin => _werkzeugMagazin;

        // Read- and write-able attribute
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

        // Constructors
        public Fraesmaschine(int ID, int MagazinGroesse)
        {
            _id = ID;
            _magazinGroesse = MagazinGroesse;
            _werkzeugMagazin = new List<string>();
            for (int i = 0; i < MagazinGroesse; i++)
                _werkzeugMagazin.Add("-");
            AktivesWerkzeug = 0;
        }

        [JsonConstructor]
        public Fraesmaschine(int ID, int MagazinGroesse, List<string> WerkzeugMagazin)
        {
            _id = ID;
            _magazinGroesse = MagazinGroesse;
            _werkzeugMagazin = WerkzeugMagazin;
            AktivesWerkzeug = 0;
        }

        // Public methods
        public void WerkzeugAufruesten(int MagazinPlatz, string Werkzeug)
        {
            ValidateMagazinPlatz(MagazinPlatz);
            _werkzeugMagazin[MagazinPlatz] = Werkzeug;
        }

        public string WerkstueckBearbeiten()
        {
            if (string.IsNullOrWhiteSpace(WerkzeugMagazin[AktivesWerkzeug]))
            {
                throw new Exception("Kein Fraeskopf eingespannt!");
            }
            return $"Werkstück wird mit {_werkzeugMagazin[AktivesWerkzeug]} gefraest.";
        }

    }
}
