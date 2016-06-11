using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task6.Tests
{
    [TestFixture]
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
        public void CanWerkstueckFraesen()
        {
            GenericTests.CanWerkstueckBearbeiten(new Drehmaschine(2, 1));
        }

        [Test]
        public void CanSetActiveValidWerkzeugOfDrehmaschiné()
        {
            GenericTests.CanSetActiveValidWerkzeug(new Drehmaschine(2, 4));
        }

        [Test]
        public void CannnotSetActiveInvalidWerkzeugOfDrehmaschine()
        {
            GenericTests.CannnotSetActiveInvalidWerkzeug(new Drehmaschine(2, 4));
        }

    }
}
