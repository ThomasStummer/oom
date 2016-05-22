﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task4
{
    class GenericTests
    {
        static public void CanCreateWerkzeugmaschine(Werkzeugmaschine werkzeugMaschine)
        {
            Assert.IsTrue(werkzeugMaschine.ID == 2);
            Assert.IsTrue(werkzeugMaschine.MagazinGroesse == 4);
        }

        static public void CanWerkzeugAufruesten(Werkzeugmaschine werkzeugMaschine)
        {
            for (int i = 0; i < werkzeugMaschine.MagazinGroesse; i++)
            {
                werkzeugMaschine.WerkzeugAufruesten(i, "Werkzeug_" + i);
                Assert.IsTrue(werkzeugMaschine.WerkzeugMagazin[i] == "Werkzeug_" + i);
            }
        }

        static public void CanWerkstueckBearbeiten(Werkzeugmaschine werkzeugMaschine)
        {
            werkzeugMaschine.WerkzeugAufruesten(0, "Werkzeug_0");
            if (werkzeugMaschine is Fraesmaschine)
                Assert.IsTrue(werkzeugMaschine.WerkstueckBearbeiten() == "Werkstück wird mit Werkzeug_0 gefraest.");
            else
                Assert.IsTrue(werkzeugMaschine.WerkstueckBearbeiten() == "Werkstück wird mit Werkzeug_0 gedreht.");
        }

        static public void CanSetActiveValidWerkzeug(Werkzeugmaschine werkzeugMaschine)
        {
            Assert.IsTrue(werkzeugMaschine.AktivesWerkzeug == 0);
            werkzeugMaschine.AktivesWerkzeug = 2;
            Assert.IsTrue(werkzeugMaschine.AktivesWerkzeug == 2);
        }

        static public void CannnotSetActiveInvalidWerkzeug(Werkzeugmaschine werkzeugMaschine)
        {
            Assert.IsTrue(werkzeugMaschine.AktivesWerkzeug == 0);
            Assert.Catch(() => werkzeugMaschine.AktivesWerkzeug = 7);
        }

    }
}
