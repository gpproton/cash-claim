using AutoFilterer.Types;
using CashClaim.Common.Dtos;
using CashClaim.Common.Helpers;
using XClaim.Web.Server.Entities;
using AutoMapperProfile = AutoMapper.Profile;

namespace XClaim.Web.Server;

public class MapperProfile : AutoMapperProfile {
    public MapperProfile() {
        CreateMap<BankEntity, BankResponse>().ReverseMap();
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
        CreateMap<NotificationEntity, NotificationResponse>().ReverseMap();
        CreateMap<SettingEntity, SettingResponse>().ReverseMap();
        CreateMap<BankAccountEntity, BankAccountResponse>().ReverseMap();
        CreateMap<ServerEntity, ServerResponse>().ReverseMap();
        CreateMap<ServerStateResponse, ServerResponse>().ReverseMap();
        CreateMap<TransferRequestResponse, TransferRequestEntity>().ReverseMap();
        CreateMap<PaginationFilterBase, PaginationFilter>().ReverseMap();
    }
}