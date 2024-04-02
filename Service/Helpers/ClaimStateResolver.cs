using CashClaim.Common.Dtos;
using CashClaim.Common.Enums;
using XClaim.Web.Server.Entities;

namespace XClaim.Web.Server.Helpers;

public class ClaimStateResolver {
    private readonly IdentityHelper _identity;
    private ClaimEntity? _claim;
    
    public ClaimStateResolver(IdentityHelper identity) {
        _identity = identity;
    }

    public ClaimStateResolver InitializeState(ClaimEntity? claim) {
        _claim = claim;

        return this;
    }
    
    private bool StateInactive { get { return _claim?.Status is ClaimStatus.Rejected || _claim?.RejectedAt != null || _claim?.RejectedById != null || _claim?.CancelledAt != null; }}
    private bool StatePending { get { return _claim?.Status == ClaimStatus.Pending; }}
    private bool StateReviewed { get { return !StatePending && _claim is { ReviewedAt: { }, ReviewedById: { } }; }}
    private bool StateConfirmed { get { return StateReviewed && _claim is { ConfirmedAt: { }, ApprovedById: { } }; }}
    private bool StateApproved { get { return StateConfirmed && _claim is { ApprovedAt: { }, ApprovedById: { } }; }}

    public async Task<ClaimEntity?> Transform(ClaimStatus preferredAction = ClaimStatus.None) {
        var user = await _identity.GetUser();
        if (user?.Id == null || _claim == null)
            return _claim;

        var currentTime = DateTime.Now;
        var id = user.Id;
        var owner = id == _claim.OwnerId;

        void SetReviewed() {
            _claim!.ReviewedAt = currentTime;
            _claim.ReviewedById = id;
        }
        void SetConfirmed() {
            _claim.ConfirmedAt = currentTime;
            _claim.ConfirmedById = id;
        }
        void SetApproved() {
            _claim!.ApprovedAt = currentTime;
            _claim.ApprovedById = id;
        }
        
        switch (preferredAction) {
            case ClaimStatus.Cancelled:
                _claim.CancelledAt = currentTime;
                _claim.Status = ClaimStatus.Cancelled;
                break;
            case ClaimStatus.Rejected:
                _claim.RejectedAt = currentTime;
                _claim.RejectedById = id;
                _claim.Status = ClaimStatus.Rejected;
                break;
            case ClaimStatus.None:
            case ClaimStatus.Pending:
            case ClaimStatus.Reviewed:
            case ClaimStatus.Confirmed:
            case ClaimStatus.Approved:
            default:
                switch (user.Permission) {
                    case UserPermission.System:
                    case UserPermission.Administrator:
                        if (owner && _claim.Status < ClaimStatus.Confirmed) {
                            SetReviewed();
                            SetConfirmed();
                            _claim.Status = ClaimStatus.Confirmed;
                        } else {
                            SetApproved();
                            _claim.Status = ClaimStatus.Approved;
                        }
                        break;
                    case UserPermission.Finance:
                        if (owner && _claim.Status < ClaimStatus.Reviewed) {
                            SetReviewed();
                            SetConfirmed();
                        } else
                            SetConfirmed();
                        _claim.Status = ClaimStatus.Confirmed;
                        break;
                    case UserPermission.Lead:
                        SetReviewed();
                        _claim.Status = ClaimStatus.Reviewed;
                        break;
                    case UserPermission.Cashier:
                    case UserPermission.Standard:
                    case UserPermission.Anonymous:
                    default:
                        break;
                }
                break;
        }

        return _claim;
    }

    public async Task<ClaimStateResponse> Resolve() {
        return new ClaimStateResponse {
            Id = _claim!.Id,
            Description = _claim?.Description,
            Notes = _claim?.Notes,
            Currency = _claim!.Currency!.Symbol,
            Amount = _claim.Amount,
            Status = _claim.Status,
            Category = _claim!.Category!.Name,
            Owner = $"{_claim!.Owner!.FirstName} {_claim!.Owner!.LastName}",
            OwnerId = _claim.OwnerId,
            CreatedAt = _claim.CreatedAt,
            Approved = this.StateApproved,
            Completed = await this.IsCompleted(),
            Payed = _claim!.Payment != null && _claim!.Payment!.Confirmed,
        };
    }

    private async Task<bool> IsCompleted() {
        var user = await _identity.GetUser();
        if (user == null || _claim == null)
            return false;
        switch (user.Permission) {
            case UserPermission.System:
            case UserPermission.Administrator:
                return StateApproved || StateInactive;
            case UserPermission.Finance:
                return StateConfirmed || StateInactive;
            case UserPermission.Lead:
                return StateReviewed || StateInactive;
            case UserPermission.Cashier:
            case UserPermission.Standard:
            case UserPermission.Anonymous:
            default:
                return !StatePending || StateInactive;
        }
    }
}