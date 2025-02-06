using Vanilla.Domain.Common;

namespace Vanilla.Application.Common;

public interface ISession
{
    public UserId UserId { get; }

    public DateTime Now { get; }
}