using EFCoreSimpleExample.Application.Configurations;
using EFCoreSimpleExample.Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace EFCoreSimpleExample.Application.Context;

public class ApplicationDbContext : DbContext
{
    // конфигурация БД через DI
    private readonly IConfiguration _configuration;
    public ApplicationDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
        Database.EnsureCreated();
    }

    private DbSet<Book> Books;
    private DbSet<Page> Pages;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // получение строки подключения из appsettings.json
        optionsBuilder
            .UseSqlServer(_configuration.GetConnectionString("SimpleDatabase"))
            .UseLoggerFactory(CreateLoggerFactory())
            .EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    // пример логирования в консоль
    public ILoggerFactory CreateLoggerFactory() =>
        LoggerFactory.Create(builder => builder.AddConsole());
}
