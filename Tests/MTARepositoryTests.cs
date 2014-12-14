using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTAServiceStatus.Repositories;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class MTARepositoryTests
    {
        [TestMethod]
        public async Task GetSubwayStatusAsyncTests()
        {
            var repo = new MTARepository();
            var result = await repo.GetStatusAsync();

            Assert.IsNotNull(result);

            Assert.AreNotEqual<int>(0, result.BT.Count);

            Assert.AreNotEqual<int>(0, result.bus.Count);

            Assert.AreNotEqual<int>(0, result.LIRR.Count);

            Assert.AreNotEqual<int>(0, result.MetroNorth.Count);

            Assert.AreNotEqual<int>(0, result.subway.Count);

            Assert.AreEqual<int>(0, result.responsecode);
        }
    }
}
