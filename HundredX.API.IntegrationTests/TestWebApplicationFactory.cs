// Tests/Infrastructure/ApiFactory.cs
using Microsoft.AspNetCore.Mvc.Testing;

namespace HundredX.API.IntegrationTests.Infrastructure;

public class ApiFactory : WebApplicationFactory<Program>
{
    // Optional: override configuration to set connection string from env if needed
    // protected override void ConfigureWebHost(IWebHostBuilder builder)
    // {
    //     builder.ConfigureAppConfiguration((ctx, cfg) =>
    //     {
    //         var conn = Environment.GetEnvironmentVariable("HUNDREDX_CS");
    //         if (!string.IsNullOrWhiteSpace(conn))
    //             cfg.AddInMemoryCollection(new Dictionary<string,string?>
    //             {
    //                 ["ConnectionStrings:Hundredx"] = conn
    //             });
    //     });
    // }
}
