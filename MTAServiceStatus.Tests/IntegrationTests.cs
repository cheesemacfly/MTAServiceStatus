using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace MTAServiceStatus.Tests
{
    [TestClass]
    public class IntegrationTests
    {
        [TestMethod]
        public async Task GetLinesAsyncTests()
        {
            var status = new MTASubwayStatus();

            var lines = await status.GetLinesAsync();

            Assert.IsNotNull(lines);

            Assert.AreNotEqual(0, lines.Count);
        }

        [TestMethod]
        public async Task GetRawServiceAsyncTests()
        {
            var repo = new MTARepository();

            var result = await repo.GetRawServiceAsync();

            Assert.IsNotNull(result);

            Assert.AreNotEqual(0, result.BT.Count);

            Assert.AreNotEqual(0, result.Bus.Count);

            Assert.AreNotEqual(0, result.LIRR.Count);

            Assert.AreNotEqual(0, result.MetroNorth.Count);

            Assert.AreNotEqual(0, result.Subway.Count);

            Assert.AreEqual(0, result.ResponseCode);
        }

        [TestMethod]
        public async Task GetServiceAsyncTests()
        {
            var repo = new MTARepository();

            var result = await repo.GetServiceAsync();

            Assert.IsNotNull(result);

            Assert.AreNotEqual(0, result.BT.Count);

            Assert.AreNotEqual(0, result.Bus.Count);

            Assert.AreNotEqual(0, result.LIRR.Count);

            Assert.AreNotEqual(0, result.MetroNorth.Count);

            Assert.AreNotEqual(0, result.Subway.Count);
        }
    }
}
