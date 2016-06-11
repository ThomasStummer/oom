using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    public interface IWerkzeugmaschine
    {
        int ID { get; }
        int MagazinGroesse { get; }
        int AktivesWerkzeug { get; set; }
        string[] WerkzeugMagazin { get; }
        void WerkzeugAufruesten(int MagazinPlatz, string Werkzeug);
        string WerkzeugLangsamAufruesten(int MagazinPlatz, string Werkzeug);
        string WerkstueckBearbeiten();
        string WerkstueckLangsamBearbeiten();
    }
}
