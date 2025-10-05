using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HundredX.API.Controllers;
using HundredX.API.Data;
using HundredX.API.Models;
using Microsoft.AspNetCore.Mvc;          // for OkObjectResult
using Microsoft.EntityFrameworkCore;     // for InMemory EF
using Xunit;

namespace HundredX.API.IntegrationTests
{
    public class HistoricalRecordsMinimalTests
    {
        private static HundredxContext NewContext()
        {
            var opts = new DbContextOptionsBuilder<HundredxContext>()
                .UseInMemoryDatabase("hundredx-tests-" + Guid.NewGuid())
                .Options;

            return new HundredxContext(opts);
        }

        [Fact]
        public async Task GetAll_CountIs3()
        {
            // Arrange
            using var db = NewContext();
            db.HistoricalRecords.AddRange(
                new HistoricalRecord
                {
                    CryptocurrencyId = 1,
                    RecordDate = new DateTime(2024, 1, 1),
                    Rank = 1, Price = 1.23m, Supply = 100m, Volume = 1000m, MarketCap = 12345m
                },
                new HistoricalRecord
                {
                    CryptocurrencyId = 2,
                    RecordDate = new DateTime(2024, 1, 2),
                    Rank = 2, Price = 2.34m
                },
                new HistoricalRecord
                {
                    CryptocurrencyId = 3,
                    RecordDate = new DateTime(2024, 1, 3),
                    Rank = 3
                }
            );
            await db.SaveChangesAsync();

            var controller = new HistoricalRecordsController(db);

            // Act
            var action = await controller.GetAll();

            // Assert
            var ok = Assert.IsType<OkObjectResult>(action.Result);
            var items = Assert.IsAssignableFrom<IEnumerable<HistoricalRecord>>(ok.Value);
            Assert.Equal(3, items.Count());
        }

        [Fact]
        public async Task GetAll_EmptyDb_CountIs0()
        {
            // Arrange
            using var db = NewContext();
            var controller = new HistoricalRecordsController(db);

            // Act
            var action = await controller.GetAll();

            // Assert
            var ok = Assert.IsType<OkObjectResult>(action.Result);
            var items = Assert.IsAssignableFrom<IEnumerable<HistoricalRecord>>(ok.Value);
            Assert.Empty(items);
        }
    }
}
