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
        CreateMap<CommentEntity, CommentResponse>().ReverseMap();
        CreateMap<CompanyEntity, CompanyResponse>().ReverseMap();
        CreateMap<EventEntity, EventResponse>().ReverseMap();
        CreateMap<FileEntity, FileResponse>().ReverseMap();
        CreateMap<PaymentEntity, PaymentResponse>().ReverseMap();
        CreateMap<TeamEntity, Team>().ReverseMap();
        CreateMap<UserEntity, User>().ReverseMap();
    }
}