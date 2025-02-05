using Vanilla.Dtos.Common;

namespace Vanilla.Dtos.Responses.User;

public record GetAllUserResponseDto
{
    public PageDto PageMetadata { get; set; } = null!;
    public List<UserDto> Users { get; set; } = new();
}