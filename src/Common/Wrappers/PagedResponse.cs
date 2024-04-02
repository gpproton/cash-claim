using XClaim.Common.Helpers;

namespace XClaim.Common.Wrappers;

public class PagedResponse<T> : Response<T> {
    public PagedResponse() { }

    public PagedResponse(T? data, int total, PaginationFilter filter) {
        this.Data = data;
        this.Message = string.Empty;
        this.Total = total;
        this.Page = filter.Page;
        this.PerPage = filter.PerPage;
    }

    public int Page { get; set; }
    public int PerPage { get; set; }
    public int Total { get; set; }

    public int TotalPages {
        get {
            var total = ((double)this.Total / this.PerPage);
            return Convert.ToInt32(Math.Ceiling(total));
        }
    }
}