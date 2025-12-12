namespace AcademiasAPI.Domain.Dto.Pagination;

public class PaginateResponseDto<T>
where T : ReadBaseDto
{
    public int PageSize { get; set; }
    public int Total { get; set; }
    public int Page { get; set; }
    public required ICollection<T> Results { get; set; }
}