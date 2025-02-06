using StronglyTypedIds;

namespace Vanilla.Domain.Common;

public interface IGuid {}

//partial: for splitting large struct
// [StronglyTypedId(Template.Guid, "guid-efcore")]
[StronglyTypedId]
public partial struct UserId : IGuid
{
    public static implicit operator UserId(Guid guid)
    {
        return new UserId(guid);
    }
}