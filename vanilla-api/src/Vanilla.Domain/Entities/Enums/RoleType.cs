using System.ComponentModel;

namespace Vanilla.Domain.Entities.Enums;

public enum RoleType
{
    [Description("Regular")]
    Regular,
    [Description("Creator")]
    Creator,
    [Description("Admin")]
    Admin,
    [Description("None")]
    None,
}