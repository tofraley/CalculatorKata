using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CalculatorKata.Api.Controllers;

namespace AdderKata.Tests
{
    public class CalculatorController_UT
    {
        private readonly CalculatorController sut;

        public CalculatorController_UT()
        {
            sut = new CalculatorController();
        }

        [Fact]
        public async Task AddShould_Return5_When2And3()
        {
            var result = await sut.Add(2, 3);

            var actually = Assert.IsType<OkObjectResult>(result);

            Assert.Equal(5, actually.Value);
        }

        [Fact]
        public async Task SubtractShould_Return5_When10And5()
        {
            var result = await sut.Subtract(10, 5);

            var actually = Assert.IsType<OkObjectResult>(result);

            Assert.Equal(5, actually.Value);
        }

        [Fact]
        public async Task SubtractShould_ReturnNegative5_When5And10()
        {
            var result = await sut.Subtract(5, 10);

            var actually = Assert.IsType<OkObjectResult>(result);

            Assert.Equal(-5, actually.Value);
        }

        [Fact]
        public async Task MultiplyShould_Return25_When5And5()
        {
            var result = await sut.Multiply(5, 5);

            var actually = Assert.IsType<OkObjectResult>(result);

            Assert.Equal(25, actually.Value);
        }

        [Fact]
        public async Task MultiplyShould_ReturnNegative25_WhenNegative5And5()
        {
            var result = await sut.Multiply(-5, 5);

            var actually = Assert.IsType<OkObjectResult>(result);

            Assert.Equal(-25, actually.Value);
        }

        [Fact]
        public async Task DivideShould_Return25_When100And4()
        {
            var result = await sut.Divide(100, 4);

            var actually = Assert.IsType<OkObjectResult>(result);
            
            Assert.Equal(25.0, actually.Value);
        }

        [Fact]
        public async Task DivideShould_Return4Hundredths_When4And100()
        {
            var result = await sut.Divide(4, 100);

            var actually = Assert.IsType<OkObjectResult>(result);

            Assert.Equal(.04, actually.Value);
        }

        [Fact]
        public async Task DivideShould_ReturnBadRequest_When100AndZero()
        {
            var result = await sut.Divide(100, 0);

            Assert.IsType<BadRequestResult>(result);
        }
    }
}
