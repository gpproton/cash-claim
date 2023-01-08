using XClaim.Common.Dtos;
using XClaim.Common.Entities;
using AutoMapperProfile = AutoMapper.Profile;

namespace XClaim.Web.Server;

public class MapperProfile : AutoMapperProfile {
    public MapperProfile() {
        CreateMap<BankEntity, Bank>().ReverseMap();
        CreateMap<BankAccountEntity, BankAccount>().ReverseMap();
        CreateMap<CategoryEntity, Category>().ReverseMap();
        CreateMap<ClaimEntity, Claim>().ReverseMap();
        CreateMap<CommentEntity, Comment>().ReverseMap();
        CreateMap<CompanyEntity, Company>().ReverseMap();
        CreateMap<EventEntity, EventResponse>().ReverseMap();
        CreateMap<FileEntity, FileResponse>().ReverseMap();
        CreateMap<PaymentEntity, Payment>().ReverseMap();
        CreateMap<TeamEntity, Team>().ReverseMap();
        CreateMap<UserEntity, User>().ReverseMap();
    }
}