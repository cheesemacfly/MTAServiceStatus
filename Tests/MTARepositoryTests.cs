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
    public class MTARepositoryTests
    {
        [Test]
        public void GetRawServiceAsyncTests()
        {
            var repo = new MTARepository();

            Assert.DoesNotThrow(async () =>
            {
                var result = await repo.GetRawServiceAsync();

                Assert.IsNotNull(result);

                Assert.IsNotEmpty(result.BT);

                Assert.IsNotEmpty(result.Bus);

                Assert.IsNotEmpty(result.LIRR);

                Assert.IsNotEmpty(result.MetroNorth);

                Assert.IsNotEmpty(result.Subway);

                Assert.AreEqual(0, result.ResponseCode);
            });
        }

        [Test]
        public void GetServiceAsyncTests()
        {
            var repo = new MTARepository();

            Assert.DoesNotThrow(async () =>
            {
                var result = await repo.GetServiceAsync();

                Assert.IsNotNull(result);

                Assert.IsNotEmpty(result.BT);

                Assert.IsNotEmpty(result.Bus);

                Assert.IsNotEmpty(result.LIRR);

                Assert.IsNotEmpty(result.MetroNorth);

                Assert.IsNotEmpty(result.Subway);
            });
        }
    }
}
