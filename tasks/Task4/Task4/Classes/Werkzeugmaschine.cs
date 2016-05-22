using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public interface Werkzeugmaschine
    {
        int GetID();
        int GetMagazinGroesse();
        string GetWerkzeugMagazin(int MagazinPlatz);
        void WerkzeugAufruesten(int MagazinPlatz, string Werkzeug);
        string WerkstueckBearbeiten();
    }
}
