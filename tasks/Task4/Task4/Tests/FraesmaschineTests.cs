using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task4.Tests
{
    class FraesmaschineTests
    {
        [Test]
        public void CanCreateFraesmaschine()
        {
            GenericTests.CanCreateWerkzeugmaschine(new Fraesmaschine(2, 4));
        }

        [Test]
        public void CanFraesmaschineAufruesten()
        {
            GenericTests.CanWerkzeugAufruesten(new Fraesmaschine(2, 4));
        }

        [Test]
        static public void CanWerkstueckFraesen()
        {
            GenericTests.CanWerkstueckBearbeiten(new Fraesmaschine(2, 1));
        }

        [Test]
        public void CanSetActiveValidWerkzeugOfFraesmaschiné()
        {
            var fraesmaschine = new Fraesmaschine(2, 4);
            Assert.IsTrue(fraesmaschine.AktivesWerkzeug == 0);
            fraesmaschine.AktivesWerkzeug = 2;
            Assert.IsTrue(fraesmaschine.AktivesWerkzeug == 2);
        }

        [Test]
        public void CannnotSetActiveInvalidWerkzeugOfFraesmaschine()
        {
            var fraesmaschine = new Fraesmaschine(2, 4);
            Assert.IsTrue(fraesmaschine.AktivesWerkzeug == 0);
            Assert.Catch(() => fraesmaschine.AktivesWerkzeug = 7);
        }

    }
}
