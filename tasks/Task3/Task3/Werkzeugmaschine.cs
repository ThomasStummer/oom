using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public interface Werkzeugmaschine
    {
        int ID();
        int MagazinGroesse();
        string WerkzeugMagazin(int MagazinPlatz);
        void WerkzeugAufruesten(int MagazinPlatz, string Werkzeug);
        void WerkstueckBearbeiten();
    }
}
