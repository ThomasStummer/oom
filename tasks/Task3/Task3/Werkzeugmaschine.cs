using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public interface Werkzeugmaschine
    {
        void WerkzeugAufruesten(int MagazinPlatz, string Werkzeug);

        void WerkstueckBearbeiten();
    }
}
