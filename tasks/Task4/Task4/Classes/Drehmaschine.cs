﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Task4
{
    class Drehmaschine : Werkzeugmaschine
    {
        // Private members
        int _id;
        readonly int _magazinGroesse;
        string [] _werkzeugMagazin;        
        int _aktivesWerkzeug;

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
        void ValidateMagazinPlatz(int platz)
        {
            if (platz < 0 || platz > MagazinGroesse - 1)
            {
                throw new Exception("Magazinplatz nicht vorhanden!");
            }
        }

        // Constructor
        public Drehmaschine(int ID, int MagazinGroesse)
        {
            _id = ID;
            _magazinGroesse = MagazinGroesse;
            _werkzeugMagazin = new string[_magazinGroesse];
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
            if(string.IsNullOrWhiteSpace(WerkzeugMagazin[AktivesWerkzeug]))
            { 
                throw new Exception("Kein Meißel eingespannt!");
            }
            return $"Werkstück wird mit {_werkzeugMagazin[AktivesWerkzeug]} gedreht.";
        }
        
    }
}
