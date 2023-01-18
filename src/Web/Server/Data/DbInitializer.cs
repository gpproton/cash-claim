using Microsoft.EntityFrameworkCore;
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
            new DomainEntity { Id = Guid.NewGuid(), CreatedAt = time, Address = "agboolas@outlook.com"}
        };

        var currencies = new List<CurrencyEntity> {
            new CurrencyEntity { Id = Guid.NewGuid(), CreatedAt = time, Name = "Naira", Symbol = "₦" },
            new CurrencyEntity { Id = Guid.NewGuid(), CreatedAt = time, Name = "Dollar", Symbol = "$" }
        };

        var companies = new List<CompanyEntity> {
            new CompanyEntity() { Id = Guid.NewGuid(), CreatedAt = time, ShortName = "BHN LTD", FullName = "MCPL LTD - BHN Division" },
            new CompanyEntity() { Id = Guid.NewGuid(), CreatedAt = time, ShortName = "MCPL LTD", FullName = "Multi Consumer Product LTD" },
            new CompanyEntity() { Id = Guid.NewGuid(), CreatedAt = time, ShortName = "Dufil", FullName = "Dufil Prima Foods Plc" }
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
            new TeamEntity { Id = Guid.NewGuid(), CreatedAt = time, Name = "QA Dept", CompanyId = companies[2].Id  }
        };
        
        var users = new List<UserEntity> {
            new UserEntity { Id = Guid.NewGuid(), CreatedAt = time, Permission = UserPermission.Administrator, FirstName = "John", LastName = "Doe", UserName = "john_doe", Email = "john.doe@test.com", Phone = "+23401", TeamId = teams[0].Id,CompanyId = companies[0].Id },
            new UserEntity { Id = Guid.NewGuid(), CreatedAt = time, FirstName = "Jane", LastName = "Doe", UserName = "jane_doe", Email = "jane.doe@test.com", Phone = "+23402", TeamId = teams[1].Id, CompanyId = companies[1].Id },
            new UserEntity { Id = Guid.NewGuid(), CreatedAt = time, FirstName = "Johnny ", LastName = "Test", UserName = "johnny_test", Email = "johnny.test@test.com", Phone = "+23403", TeamId = teams[2].Id, CompanyId = companies[2].Id },
        };
        
        _modelBuilder.Entity<BankEntity>().HasData(banks);
        _modelBuilder.Entity<DomainEntity>().HasData(domains);
        _modelBuilder.Entity<CurrencyEntity>().HasData(currencies);
        _modelBuilder.Entity<CompanyEntity>().HasData(companies);
        _modelBuilder.Entity<CategoryEntity>().HasData(categories);
        _modelBuilder.Entity<UserEntity>().HasData(users);
        _modelBuilder.Entity<TeamEntity>().HasData(teams);
    }
}