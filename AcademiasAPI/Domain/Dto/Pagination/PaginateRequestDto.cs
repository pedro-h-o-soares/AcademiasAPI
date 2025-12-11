namespace AcademiasAPI.Domain.Dto.Pagination;

public class PaginateRequestDto
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}