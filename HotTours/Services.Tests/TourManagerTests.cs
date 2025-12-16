using Ahatornn.TestGenerator;
using Entities;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Repository.Contracts;
using Xunit;

namespace Services.Tests
{
    /// <summary>
    /// Тесты для <see cref="TourManager"/>
    /// </summary>
    public class TourManagerTests
    {
        private readonly TourManager tourManager;
        private readonly Mock<IStorage> storageMock = new();
        public TourManagerTests()
        {
            var loggerFactory = new Mock<ILoggerFactory>();
            loggerFactory.Setup(x => x.CreateLogger(It.IsAny<string>())).Returns(Mock.Of<ILogger>());
            tourManager = new(storageMock.Object, loggerFactory.Object);
        }


        /// <summary>
        /// <see cref="TourManager.Add(Tour, CancellationToken)"/> должен работать
        /// </summary>
        [Fact]
        public async Task AddShouldWork()
        {
            // Arrange
            var tour = TestEntityProvider.Shared.Create<Tour>();

            // Act
            await tourManager.Add(tour, CancellationToken.None);

            // Assert
            storageMock.Verify(mock => mock.Add(tour, CancellationToken.None), Times.Once());
            storageMock.VerifyNoOtherCalls();
        }

        /// <summary>
        /// <see cref="TourManager.Delete(Guid, CancellationToken)"/> должен работать
        /// </summary>
        [Fact]
        public async Task RemoveShouldWork()
        {
            // Arrange
            var tour = TestEntityProvider.Shared.Create<Tour>();

            // Act
            await tourManager.Delete(tour.Id, CancellationToken.None);

            // Assert
            storageMock.Verify(mock => mock.Delete(tour, CancellationToken.None), Times.Once());
            storageMock.VerifyNoOtherCalls();
        }

        /// <summary>
        /// <see cref="TourManager.GetAll(CancellationToken)"/>
        /// должен вернуть пустой список
        /// </summary>
        [Fact]
        public async Task GetAllShouldReturnEmpty()
        {
            // Arrange
            storageMock.Setup(mock => mock.GetAll(CancellationToken.None))
                .ReturnsAsync([]);

            // Act
            var actual = await tourManager.GetAll(CancellationToken.None);

            // Assert
            actual.Should().BeEmpty();
        }

        /// <summary>
        /// <see cref="TourManager.GetAll(CancellationToken)"/>
        /// должен вернуть список со значением.
        /// </summary>
        [Fact]
        public async Task GetAllShouldReturnValue()
        {
            // Arrange
            ICollection<Tour> expected = new List<Tour>()
            {
                new ()
            };
            storageMock.Setup(mock => mock.GetAll(CancellationToken.None))
            .ReturnsAsync(expected);

            // Act
            var actual = await tourManager.GetAll(CancellationToken.None);

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        /// <summary>
        /// <see cref="TourManager.Update(Tour, CancellationToken)"/> должен работать
        /// </summary>
        [Fact]
        public async Task UpdateShouldWork()
        {
            // Arrange
            var tour = TestEntityProvider.Shared.Create<Tour>();

            // Act
            await tourManager.Update(tour, CancellationToken.None);

            // Assert
            storageMock.Verify(mock => mock.Update(tour, CancellationToken.None), Times.Once());
            storageMock.VerifyNoOtherCalls();
        }

        /// <summary>
        /// <see cref="TourManager.GetStatistics(CancellationToken)"/> должен работать
        /// </summary>
        [Fact]
        public async Task GetStatisticsShouldWork()
        {
            // Arrange
            var expected = new TourStatistics
            {
                TourCount = 2,
                TotalPriceAllTours = 300m,
                TourCountCharge = 1,
                TourSumCharge = 20m
            };

            storageMock
                .Setup(x => x.GetStatistics(It.IsAny<CancellationToken>()))
                .ReturnsAsync(expected);

            // Act
            var actual = await tourManager.GetStatistics(CancellationToken.None);

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }

        /// <summary>
        ///<see cref="TourManager.GetById(Guid, CancellationToken)"/> должен работать
        /// </summary>
        [Fact]
        public async Task GetByIdShouldWork()
        {
            // Arrange
            var tour = TestEntityProvider.Shared.Create<Tour>();

            // Act
            await tourManager.GetById(tour.Id, CancellationToken.None);

            // Assert
            storageMock.Verify(mock => mock.GetById(tour.Id, CancellationToken.None), Times.Once());
            storageMock.VerifyNoOtherCalls();
        }
    }
}
