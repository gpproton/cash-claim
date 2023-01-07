using XClaim.Common.Dtos;
using XClaim.Common.Entities;
using AutoMapperProfile = AutoMapper.Profile;

namespace XClaim.Web.Server;

public class MapperProfile : AutoMapperProfile {
    public MapperProfile() {
        CreateMap<BankEntity, Bank>();
        CreateMap<BankAccountEntity, BankAccount>();
        CreateMap<CategoryEntity, Category>();
        CreateMap<Category, CategoryEntity>();
        CreateMap<ClaimEntity, Claim>();
        CreateMap<CommentEntity, Comment>();
        CreateMap<CompanyEntity, Company>();
        CreateMap<EventEntity, EventDto>();
        CreateMap<FileEntity, FileDto>();
        CreateMap<PaymentEntity, Payment>();
        CreateMap<TeamEntity, Team>();
        CreateMap<UserEntity, User>();
        CreateMap<User, UserEntity>();
    }
}