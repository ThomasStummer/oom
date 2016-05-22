using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task4.Tests
{
    class DrehmaschineTests
    {
        [Test]
        public void CanCreateDrehmaschine()
        {
            GenericTests.CanCreateWerkzeugmaschine(new Drehmaschine(2, 4));
        }

        [Test]
        public void CanDrehmaschineAufruesten()
        {
            GenericTests.CanWerkzeugAufruesten(new Drehmaschine(2, 4));
        }

        [Test]
        static public void CanWerkstueckFraesen()
        {
            GenericTests.CanWerkstueckBearbeiten(new Drehmaschine(2, 1));
        }

        [Test]
        public void CanSetActiveValidWerkzeugOfDrehmaschiné()
        {
            var drehmaschine = new Drehmaschine(2, 4);
            Assert.IsTrue(drehmaschine.AktivesWerkzeug == 0);
            drehmaschine.AktivesWerkzeug = 2;
            Assert.IsTrue(drehmaschine.AktivesWerkzeug == 2);
        }

        [Test]
        public void CannnotSetActiveInvalidWerkzeugOfDrehmaschine()
        {
            var drehmaschine = new Drehmaschine(2, 4);
            Assert.IsTrue(drehmaschine.AktivesWerkzeug == 0);
            Assert.Catch(() => drehmaschine.AktivesWerkzeug = 7);
        }

    }
}
