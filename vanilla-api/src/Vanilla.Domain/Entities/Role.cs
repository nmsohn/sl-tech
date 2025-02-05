using Vanilla.Domain.Entities.Enums;

namespace Vanilla.Domain.Entities;

public class Role : Entity<RoleId>, IAuditable
{
    public override RoleId Id { get; set; }
    public required RoleType Type { get; set; } = RoleType.None;
    public User User { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }
}