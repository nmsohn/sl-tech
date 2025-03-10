namespace Vanilla.Domain.Common;

public interface IAuditable
{
    public DateTime? CreatedAt { get; set; } 
    public DateTime? ModifiedAt { get; set; }
}