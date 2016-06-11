using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Task6
{
    class Drehmaschine : IWerkzeugmaschine
    {
        // Private members
        private int _id;
        private readonly int _magazinGroesse;
        private string[] _werkzeugMagazin;
        private int _aktivesWerkzeug;

        // Read-only attribute
        public int ID => _id;

        // Read-only  attribute
        public int MagazinGroesse => _magazinGroesse;

        // Read-only attribute
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
        private void ValidateMagazinPlatz(int platz)
        {
            if (platz < 0 || platz > MagazinGroesse - 1)
            {
                throw new Exception("Magazinplatz nicht vorhanden!");
            }
        }

        // Constructors
        public Drehmaschine(int ID, int MagazinGroesse)
        {
            _id = ID;
            _magazinGroesse = MagazinGroesse;
            _werkzeugMagazin = new string[MagazinGroesse];
            AktivesWerkzeug = 0;
        }

        [JsonConstructor]
        public Drehmaschine(int ID, int MagazinGroesse, string[] WerkzeugMagazin)
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

        public string WerkzeugLangsamAufruesten(int MagazinPlatz, string Werkzeug)
        {
            ValidateMagazinPlatz(MagazinPlatz);
            System.Threading.Thread.Sleep(1000 + ((new Random()).Next(1000)));
            _werkzeugMagazin[MagazinPlatz] = Werkzeug;
            return $"Drehmaschine {ID} wird LANGSAM mit {_werkzeugMagazin[MagazinPlatz]} bestueckt.";
        }

        public string WerkstueckBearbeiten()
        {
            if(string.IsNullOrWhiteSpace(WerkzeugMagazin[AktivesWerkzeug]))
            { 
                throw new Exception("Kein Meißel eingespannt!");
            }
            return $"Werkstück wird mit {_werkzeugMagazin[AktivesWerkzeug]} gedreht.";
        }

        public string WerkstueckLangsamBearbeiten()
        {
            if (string.IsNullOrWhiteSpace(WerkzeugMagazin[AktivesWerkzeug]))
            {
                throw new Exception("Kein Meißel eingespannt!");
            }
            System.Threading.Thread.Sleep(1000 + ((new Random()).Next(1000)));
            return $"Werkstück wird LANGSAM mit {_werkzeugMagazin[AktivesWerkzeug]} gedreht.";
        }
    }
}
