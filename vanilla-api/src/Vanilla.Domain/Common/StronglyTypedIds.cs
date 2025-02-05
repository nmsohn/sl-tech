using StronglyTypedIds;

namespace Vanilla.Domain.Common;

public interface IGuid {}

//partial: for splitting large struct
[StronglyTypedId(Template.Guid, "guid-efcore")]
public partial struct ProductId : IGuid
{
    //implicit operator: automatic type conversion from one type to another without requiring explicit casting
    public static implicit operator ProductId(Guid guid) => new(guid);
}

[StronglyTypedId(Template.Guid, "guid-efcore")]
public partial struct UserId : IGuid
{
    public static implicit operator UserId(Guid guid) => new(guid);   
}

[StronglyTypedId(Template.Guid, "guid-efcore")]
public partial struct CategoryId : IGuid
{
    public static implicit operator CategoryId(Guid guid) => new(guid);
}

[StronglyTypedId(Template.Guid, "guid-efcore")]
public partial struct RoleId: IGuid
{
    public static implicit operator RoleId(Guid guid) => new(guid);
}

