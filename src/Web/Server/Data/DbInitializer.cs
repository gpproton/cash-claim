using Microsoft.EntityFrameworkCore;
using XClaim.Common.Entities;

namespace XClaim.Web.Server.Data;

public class DbInitializer {
    private readonly ModelBuilder _modelBuilder;

    public DbInitializer(ModelBuilder modelBuilder) {
        _modelBuilder = modelBuilder;
    }

    public void Seed() {
        var banks = new List<BankEntity> {
            new () { Id = Guid.NewGuid(), Name = "GT Bank"},
            new () { Id = Guid.NewGuid(), Name = "Zenith Bank"},
            new () { Id = Guid.NewGuid(), Name = "First Bank"}
        };

        var currencies = new List<CurrencyEntity>() { };

        var companies = new List<CompanyEntity>() { };

        var categories = new List<CategoryEntity>() { };

        var users = new List<UserEntity>() { };

        _modelBuilder.Entity<BankEntity>().HasData(banks);
    }
}