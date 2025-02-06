using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Vanilla.Domain.Common;
using Common_ISession = Vanilla.Application.Common.ISession;

namespace Vanilla.Application.Common;

public class Session : Common_ISession
{
    public UserId UserId { get; private init; }

    public DateTime Now => DateTime.Now;

    public Session(IHttpContextAccessor httpContextAccessor)
    {
        var user = httpContextAccessor.HttpContext?.User;

        var nameIdentifier = user?.FindFirst(ClaimTypes.NameIdentifier);

        if (nameIdentifier != null)
        {
            UserId = new Guid(nameIdentifier.Value);
        }
    }
}