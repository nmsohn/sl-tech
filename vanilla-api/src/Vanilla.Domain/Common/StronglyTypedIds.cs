using StronglyTypedIds;

namespace Vanilla.Domain.Common;

public interface IGuid {}

//partial: for splitting large struct
// [StronglyTypedId(Template.Guid, "guid-efcore")]
// [StronglyTypedId(Template.Guid, "guid-efcore")]
// public partial struct UserId : IGuid
// {
//     public static implicit operator UserId(Guid guid) => new(guid);   
// }
//
