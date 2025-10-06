// Tests/HistoricalRecordsHttpTests.cs
using System.Net;
using System.Net.Http.Json;
using HundredX.API.IntegrationTests.Infrastructure;
using Xunit;

public class HistoricalRecordsHttpTests : IClassFixture<ApiFactory>
{
    private readonly HttpClient _client;

    public HistoricalRecordsHttpTests(ApiFactory factory)
    {
        _client = factory.CreateClient(); // API is booted by the test host
    }

    [Fact]
    public async Task GetAll_Returns200()
    {
        var resp = await _client.GetAsync("/historicalrecords"); // adjust route
        Assert.Equal(HttpStatusCode.OK, resp.StatusCode);

        var items = await resp.Content.ReadFromJsonAsync<
            List<HundredX.API.Models.HistoricalRecord>>();
        Assert.NotNull(items);
    }

    [Fact]
    public async Task GetAll_Returns200_AndRowCountEquals3()
    {
        // Act
        var response = await _client.GetAsync("/historicalrecords");
        response.EnsureSuccessStatusCode();

        var items = await response.Content.ReadFromJsonAsync<
            List<HundredX.API.Models.HistoricalRecord>>();

        // Assert
        Assert.NotNull(items);
        Assert.Equal(3, items!.Count);
    }
}
