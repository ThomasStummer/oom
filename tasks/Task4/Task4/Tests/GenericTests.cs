using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task4
{
    [TestFixture]
    class GenericTests
    {
        static public void CanCreateWerkzeugmaschine(Werkzeugmaschine werkzeugMaschine)
        {
            Assert.IsTrue(werkzeugMaschine.GetID() == 2);
            Assert.IsTrue(werkzeugMaschine.GetMagazinGroesse() == 4);
        }

        static public void CanWerkzeugAufruesten(Werkzeugmaschine werkzeugMaschine)
        {
            for (int i = 0; i < werkzeugMaschine.GetMagazinGroesse(); i++)
            {
                werkzeugMaschine.WerkzeugAufruesten(i, "Werkzeug_" + i);
                Assert.IsTrue(werkzeugMaschine.GetWerkzeugMagazin(i) == "Werkzeug_" + i);
            }
        }

        static public void CanWerkstueckBearbeiten(Werkzeugmaschine werkzeugMaschine)
        {
            werkzeugMaschine.WerkzeugAufruesten(0, "Werkzeug_0");
            if(werkzeugMaschine is Fraesmaschine)
                Assert.IsTrue(werkzeugMaschine.WerkstueckBearbeiten() == "Werkstück wird mit Werkzeug_0 gefraest.");
            else
                Assert.IsTrue(werkzeugMaschine.WerkstueckBearbeiten() == "Werkstück wird mit Werkzeug_0 gedreht.");
        }

    }
}
