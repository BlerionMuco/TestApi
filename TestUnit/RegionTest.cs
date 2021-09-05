using Xunit;
using TestApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TestApi.Contracts;
using Microsoft.AspNetCore.Http;

namespace TestUnit
{
    public class RegionTest
    {
        public Mock<IRegionRepository> mock = new Mock<IRegionRepository>();

        [Fact]
        public void RegionFoundSuccessfully()
        {
            mock.Setup(p => p.GetRegions()).Returns(RegionsMock.Data);
            RegionController regions = new RegionController(mock.Object);
            IActionResult result = regions.DetectCountryFor("0011");
            var okResult = result as ObjectResult;

            Assert.NotNull(okResult);
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
        }

        [Fact]
        public void RegionNotFound()
        {
            mock.Setup(p => p.GetRegions()).Returns(RegionsMock.Data);
            RegionController regions = new RegionController(mock.Object);
            IActionResult result = regions.DetectCountryFor("10111");
            var notFoundResult = result as ObjectResult;

            Assert.NotNull(notFoundResult);
            Assert.Equal(StatusCodes.Status404NotFound, notFoundResult.StatusCode);
        }

        [Fact]
        public void NotMinimalLenthRequiredPhoneNumber()
        {
            mock.Setup(p => p.GetRegions()).Returns(RegionsMock.Data);
            RegionController regions = new RegionController(mock.Object);
            IActionResult result = regions.DetectCountryFor("001");
            var okResult = result as ObjectResult;

            Assert.NotNull(okResult);
            Assert.Equal(StatusCodes.Status406NotAcceptable, okResult.StatusCode);
        }

        [Fact]
        public void NotMaximalRequiredLengthPhoneNumber()
        {
            mock.Setup(p => p.GetRegions()).Returns(RegionsMock.Data);
            RegionController regions = new RegionController(mock.Object);
            IActionResult result = regions.DetectCountryFor("001123334");
            var okResult = result as ObjectResult;

            Assert.NotNull(okResult);
            Assert.Equal(StatusCodes.Status406NotAcceptable, okResult.StatusCode);
        }

        [Fact]
        public void EmptyPhoneNumber()
        {
            mock.Setup(p => p.GetRegions()).Returns(RegionsMock.Data);
            RegionController regions = new RegionController(mock.Object);
            IActionResult result = regions.DetectCountryFor("");
            var okResult = result as ObjectResult;

            Assert.NotNull(okResult);
            Assert.Equal(StatusCodes.Status400BadRequest, okResult.StatusCode);
        }
    }
}