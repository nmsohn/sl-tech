namespace Vanilla.Domain.Entities;

public class User : Entity<UserId>, IAuditable
{
   public override UserId Id { get; set; }
   public required string Email { get; set; } = null!;
   public required string Username { get; set; } = null!;
   public ICollection<Role> Roles { get; set; } = new List<Role>();
   public DateTime? CreatedAt { get; set; }
   public DateTime? ModifiedAt { get; set; }
}