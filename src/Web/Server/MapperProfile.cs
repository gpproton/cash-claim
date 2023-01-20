using AutoFilterer.Types;
using XClaim.Common.Dtos;
using XClaim.Common.Helpers;
using XClaim.Web.Server.Entities;
using AutoMapperProfile = AutoMapper.Profile;

namespace XClaim.Web.Server;

public class MapperProfile : AutoMapperProfile {
    public MapperProfile() {
        CreateMap<BankEntity, BankResponse>().ReverseMap();
        CreateMap<BankAccountEntity, BankAccountResponse>().ReverseMap();
        CreateMap<DomainEntity, DomainResponse>().ReverseMap();
        CreateMap<CurrencyEntity, CurrencyResponse>().ReverseMap();
        CreateMap<CategoryEntity, CategoryResponse>().ReverseMap();
        CreateMap<ClaimEntity, ClaimResponse>().ReverseMap();
        CreateMap<CommentEntity, CommentResponse>().ReverseMap();
        CreateMap<CompanyEntity, CompanyResponse>().ReverseMap();
        CreateMap<EventEntity, EventResponse>().ReverseMap();
        CreateMap<FileEntity, FileResponse>().ReverseMap();
        CreateMap<PaymentEntity, PaymentResponse>().ReverseMap();
        CreateMap<TeamEntity, TeamResponse>().ReverseMap();
        CreateMap<UserEntity, UserResponse>().ReverseMap();
        CreateMap<PaginationFilterBase, PaginationFilter>().ReverseMap();
    }
}