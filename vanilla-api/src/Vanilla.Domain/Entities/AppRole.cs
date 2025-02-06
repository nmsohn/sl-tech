using Microsoft.AspNetCore.Identity;

namespace Vanilla.Domain.Entities;

public class AppRole : IdentityRole<Guid>, IAuditable
{
   public override Guid Id { get; set; } = Guid.CreateVersion7();
   public DateTime? CreatedAt { get; set; }
   public DateTime? ModifiedAt { get; set; }
}