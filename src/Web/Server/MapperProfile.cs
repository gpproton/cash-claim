using XClaim.Common.Dtos;
using XClaim.Common.Entities;
using AutoMapperProfile = AutoMapper.Profile;

namespace XClaim.Web.Server;

public class MapperProfile : AutoMapperProfile {
    public MapperProfile() {
        CreateMap<BankEntity, BankResponse>().ReverseMap();
        CreateMap<BankAccountEntity, BankAccount>().ReverseMap();
        CreateMap<CategoryEntity, CategoryResponse>().ReverseMap();
        CreateMap<ClaimEntity, ClaimResponse>().ReverseMap();
        CreateMap<CommentEntity, Comment>().ReverseMap();
        CreateMap<CompanyEntity, Company>().ReverseMap();
        CreateMap<EventEntity, EventResponse>().ReverseMap();
        CreateMap<FileEntity, FileResponse>().ReverseMap();
        CreateMap<PaymentEntity, Payment>().ReverseMap();
        CreateMap<TeamEntity, Team>().ReverseMap();
        CreateMap<UserEntity, User>().ReverseMap();
    }
}