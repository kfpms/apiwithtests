using System.Linq;
using HundredX.API.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HundredX.API.Tests;

public class TestWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            // Remove the real DbContext registration (Npgsql)
            var toRemove = services.SingleOrDefault(
                d => d.ServiceType == typeof(DbContextOptions<HundredxContext>));
            if (toRemove is not null)
                services.Remove(toRemove);

            // Replace with EF InMemory for tests
            services.AddDbContext<HundredxContext>(opts =>
                opts.UseInMemoryDatabase("hundredx-tests-" + Guid.NewGuid()));

            // Ensure DB is created
            var sp = services.BuildServiceProvider();
            using var scope = sp.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<HundredxContext>();
            db.Database.EnsureCreated();
        });
    }
}
