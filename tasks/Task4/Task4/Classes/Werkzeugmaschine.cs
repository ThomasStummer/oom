using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public interface Werkzeugmaschine
    {
        int ID { get; }
        int MagazinGroesse { get; }
        int AktivesWerkzeug { get; set; }
        string[] WerkzeugMagazin { get; }
        void WerkzeugAufruesten(int MagazinPlatz, string Werkzeug);
        string WerkstueckBearbeiten();
    }
}
