using System.Threading.Tasks;
using Xunit;

namespace MTAServiceStatus.Tests
{
    public class IntegrationTests
    {

        [Fact(DisplayName = "Get Lines")]
        public async Task GetLinesAsyncTests()
        {
            var status = new MTASubwayStatus();

            var lines = await status.GetLinesAsync();

            Assert.NotNull(lines);

            Assert.NotEmpty(lines);
        }

        [Fact(DisplayName = "Get Raw Service")]
        public async Task GetRawServiceAsyncTests()
        {
            var repo = new MTARepository();

            var result = await repo.GetRawServiceAsync();

            Assert.NotNull(result);

            Assert.NotEmpty(result.BT);

            Assert.NotEmpty(result.Bus);

            Assert.NotEmpty(result.LIRR);

            Assert.NotEmpty(result.MetroNorth);

            Assert.NotEmpty(result.Subway);

            Assert.Equal(0, result.ResponseCode);
        }

        [Fact(DisplayName = "Get Service")]
        public async Task GetServiceAsyncTests()
        {
            var repo = new MTARepository();

            var result = await repo.GetServiceAsync();

            Assert.NotNull(result);

            Assert.NotEmpty(result.BT);

            Assert.NotEmpty(result.Bus);

            Assert.NotEmpty(result.LIRR);

            Assert.NotEmpty(result.MetroNorth);

            Assert.NotEmpty(result.Subway);
        }
    }
}
