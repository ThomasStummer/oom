using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task6.Tests
{
    [TestFixture]
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
        public void CanWerkstueckFraesen()
        {
            GenericTests.CanWerkstueckBearbeiten(new Fraesmaschine(2, 1));
        }

        [Test]
        public void CanSetActiveValidWerkzeugOfFraesmaschine()
        {
            GenericTests.CanSetActiveValidWerkzeug(new Fraesmaschine(2, 4));
        }

        [Test]
        public void CannnotSetActiveInvalidWerkzeugOfFraesmaschine()
        {
            GenericTests.CannnotSetActiveInvalidWerkzeug(new Fraesmaschine(2, 4));
        }

    }
}
