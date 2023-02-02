using Microsoft.EntityFrameworkCore;
using SourceExpress.ShorterGuid;
using XClaim.Common;
using XClaim.Common.Enums;
using XClaim.Web.Server.Entities;

namespace XClaim.Web.Server.Data;

public class DbInitializer {
    private readonly ModelBuilder _modelBuilder;

    public DbInitializer(ModelBuilder modelBuilder) {
        _modelBuilder = modelBuilder;
    }

    public void Seed() {
        var time = DateTime.Now;
        var banks = new List<BankEntity> {
            new BankEntity { Id = Guid.NewGuid(), CreatedAt = time, Name = "GT Bank" },
            new BankEntity { Id = Guid.NewGuid(), CreatedAt = time, Name = "Zenith Bank" },
            new BankEntity { Id = Guid.NewGuid(), CreatedAt = time, Name = "First Bank" },
            new BankEntity { Id = Guid.NewGuid(), CreatedAt = time, Name = "Access Bank" },
            new BankEntity { Id = Guid.NewGuid(), CreatedAt = time, Name = "Fidelity Bank" },
            new BankEntity { Id = Guid.NewGuid(), CreatedAt = time, Name = "First City Monument Bank" },
            new BankEntity { Id = Guid.NewGuid(), CreatedAt = time, Name = "Union Bank of Nigeria" },
            new BankEntity { Id = Guid.NewGuid(), CreatedAt = time, Name = "United Bank for Africa" },
            new BankEntity { Id = Guid.NewGuid(), CreatedAt = time, Name = "Sterling Bank" },
            new BankEntity { Id = Guid.NewGuid(), CreatedAt = time, Name = "Wema Bank" },
            new BankEntity { Id = Guid.NewGuid(), CreatedAt = time, Name = "Stanbic IBTC Bank" },
            new BankEntity { Id = Guid.NewGuid(), CreatedAt = time, Name = "Polaris Bank Limited" },
            new BankEntity { Id = Guid.NewGuid(), CreatedAt = time, Name = "Keystone Bank Limited"}
        };

        var domains = new List<DomainEntity> {
            new DomainEntity { Id = Guid.NewGuid(), CreatedAt = time, Address = "tolaram.com" },
            new DomainEntity { Id = Guid.NewGuid(), CreatedAt = time, Address = "dufil.com" },
            new DomainEntity { Id = Guid.NewGuid(), CreatedAt = time, Address = "outlook.com"}
        };

        var currencies = new List<CurrencyEntity> {
            new CurrencyEntity { Id = Guid.NewGuid(), CreatedAt = time, Name = "Naira", Code = "NGN", Symbol = "₦" },
            new CurrencyEntity { Id = Guid.NewGuid(), CreatedAt = time, Name = "US Dollar", Code = "USD", Symbol = "$" },
            new CurrencyEntity { Id = Guid.NewGuid(), CreatedAt = time, Name = "Euro", Code = "EUR", Symbol = "€" },
            new CurrencyEntity { Id = Guid.NewGuid(), CreatedAt = time, Name = "British Pounds", Code = "GBP", Symbol = "£" },
            new CurrencyEntity { Id = Guid.NewGuid(), CreatedAt = time, Name = "Rupee", Code = "INR", Symbol = "₹" }
        };

        var companies = new List<CompanyEntity> {
            new CompanyEntity() { Id = Guid.NewGuid(), CreatedAt = time, ShortName = "BHN Logistics", FullName = "MCPL LTD - BHN Division" },
            new CompanyEntity() { Id = Guid.NewGuid(), CreatedAt = time, ShortName = "MCPL LTD", FullName = "Multi Consumer Product LTD" },
            new CompanyEntity() { Id = Guid.NewGuid(), CreatedAt = time, ShortName = "Dufil Prima", FullName = "Dufil Prima Foods Plc" },
            new CompanyEntity() { Id = Guid.NewGuid(), CreatedAt = time, ShortName = "X-Claim", FullName = "X-Claim Instance Management" }
        };

        var categories = new List<CategoryEntity> {
            new CategoryEntity { Id = Guid.NewGuid(), CreatedAt = time, Name = "General Fuelling" },
            new CategoryEntity { Id = Guid.NewGuid(), CreatedAt = time, Name = "Internet Service" },
            new CategoryEntity { Id = Guid.NewGuid(), CreatedAt = time, Name = "BHN - Weekly meeting expense", CompanyId = companies[0].Id },
            new CategoryEntity { Id = Guid.NewGuid(), CreatedAt = time, Name = "MCPL - Monthly training expense", CompanyId = companies[1].Id  }
        };

        var teams = new List<TeamEntity> {
            new TeamEntity { Id = Guid.NewGuid(), CreatedAt = time, Name = "Account Dept", CompanyId = companies[0].Id },
            new TeamEntity { Id = Guid.NewGuid(), CreatedAt = time, Name = "Logistics Dept", CompanyId = companies[1].Id  },
            new TeamEntity { Id = Guid.NewGuid(), CreatedAt = time, Name = "Packaging Dept", CompanyId = companies[2].Id  }
        };

        var users = new List<UserEntity> {
            new UserEntity { Id = Guid.NewGuid(), Identifier = Guid.NewGuid().ToLowerShorterString(), CreatedAt = time, FirstName = "John", LastName = "Doe", Email = "john.doe@tolaram.com", Phone = "+234012345567", TeamId = teams[0].Id, CompanyId = companies[0].Id },
            new UserEntity { Id = Guid.NewGuid(), Identifier = Guid.NewGuid().ToLowerShorterString(), CreatedAt = time, FirstName = "Jane", LastName = "Doe", Email = "jane.doe@tolaram.com", Phone = "+234022424553", TeamId = teams[1].Id, CompanyId = companies[1].Id }
        };

        var server = new List<ServerEntity> {
            new ServerEntity { Id = Guid.NewGuid(), AdminEmail = "admin@x-claim.dev", CurrencyId = currencies[0].Id, MaintenanceText = "In-Progress", ServiceName = SharedConst.ServiceName }
        };

        _modelBuilder.Entity<BankEntity>().HasData(banks);
        _modelBuilder.Entity<DomainEntity>().HasData(domains);
        _modelBuilder.Entity<CurrencyEntity>().HasData(currencies);
        _modelBuilder.Entity<CompanyEntity>().HasData(companies);
        _modelBuilder.Entity<CategoryEntity>().HasData(categories);
        _modelBuilder.Entity<UserEntity>().HasData(users);
        _modelBuilder.Entity<TeamEntity>().HasData(teams);
        _modelBuilder.Entity<ServerEntity>().HasData(server);
    }
}