using Vanilla.Domain.Common;

namespace Vanilla.Application.Auth;

public interface ISession
{
    public UserId UserId { get; }

    public DateTime Now { get; }
}