using System.ComponentModel.DataAnnotations;
using XClaim.Common.Base;

namespace XClaim.Web.Server.Entities;

public sealed class FileEntity : BaseEntity {
    [MaxLength(256)]
    public string Name { get; set; } = string.Empty;
    [Required]
    [MaxLength(1024)]
    public string? Path { get; set; }
    [MaxLength(8)]
    public string? Extension { get; set; }
    public UserEntity? Owner { get; set; }
}