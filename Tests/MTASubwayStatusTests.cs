using MTAServiceStatus;
using MTAServiceStatus.Repositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    class MTASubwayStatusTests
    {
        [Test]
        public void GetLinesAsyncTests()
        {
            //Default constructor
            var status = new MTASubwayStatus();

            Assert.DoesNotThrow(async () =>
            {
                Assert.IsNotNull(lines);

                Assert.IsNotEmpty(lines);
            });

            //Passing a foreign repository
            var repo = new MTARepository();
            status = new MTASubwayStatus(repo);

            Assert.DoesNotThrow(async () =>
            {
                var lines = await status.GetLinesAsync();

                Assert.IsNotNull(lines);

                Assert.IsNotEmpty(lines);
            });
        }
    }
}
