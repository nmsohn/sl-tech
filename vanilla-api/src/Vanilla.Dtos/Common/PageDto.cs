namespace Vanilla.Dtos.Common;

public record PageDto
{
    public int PageCount { get; set; }
    public int TotalItemCount { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set;  }
    public bool HasPreviousPage { get; set;  }
    public bool HasNextPage { get; set;  }
}