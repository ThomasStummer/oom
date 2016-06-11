using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task6
{
    class GenericTests
    {
        public static void CanCreateWerkzeugmaschine(IWerkzeugmaschine werkzeugMaschine)
        {
            Assert.IsTrue(werkzeugMaschine.ID == 2);
            Assert.IsTrue(werkzeugMaschine.MagazinGroesse == 4);
        }

        public static void CanWerkzeugAufruesten(IWerkzeugmaschine werkzeugMaschine)
        {
            for (int i = 0; i < werkzeugMaschine.MagazinGroesse; i++)
            {
                werkzeugMaschine.WerkzeugAufruesten(i, "Werkzeug_" + i);
                Assert.IsTrue(werkzeugMaschine.WerkzeugMagazin[i] == "Werkzeug_" + i);
            }
        }

        public static void CanWerkstueckBearbeiten(IWerkzeugmaschine werkzeugMaschine)
        {
            werkzeugMaschine.WerkzeugAufruesten(0, "Werkzeug_0");
            if (werkzeugMaschine is Fraesmaschine)
                Assert.IsTrue(werkzeugMaschine.WerkstueckBearbeiten() == "Werkstück wird mit Werkzeug_0 gefraest.");
            else
                Assert.IsTrue(werkzeugMaschine.WerkstueckBearbeiten() == "Werkstück wird mit Werkzeug_0 gedreht.");
        }

        public static void CanSetActiveValidWerkzeug(IWerkzeugmaschine werkzeugMaschine)
        {
            Assert.IsTrue(werkzeugMaschine.AktivesWerkzeug == 0);
            werkzeugMaschine.AktivesWerkzeug = 2;
            Assert.IsTrue(werkzeugMaschine.AktivesWerkzeug == 2);
        }

        public static void CannnotSetActiveInvalidWerkzeug(IWerkzeugmaschine werkzeugMaschine)
        {
            Assert.IsTrue(werkzeugMaschine.AktivesWerkzeug == 0);
            Assert.Catch(() => werkzeugMaschine.AktivesWerkzeug = 7);
        }

    }
}
