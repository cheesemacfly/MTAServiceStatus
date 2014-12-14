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
        public void GetSubwayStatusAsyncTests()
        {
            var repo = new MTARepository();

            Assert.DoesNotThrow(async () =>
            {
                var result = await repo.GetStatusAsync();

                Assert.IsNotNull(result);

                Assert.IsNotEmpty(result.BT);

                Assert.IsNotEmpty(result.Bus);

                Assert.IsNotEmpty(result.LIRR);

                Assert.IsNotEmpty(result.MetroNorth);

                Assert.IsNotEmpty(result.Subway);

                Assert.AreEqual(0, result.ResponseCode);
            });
        }
    }
}
