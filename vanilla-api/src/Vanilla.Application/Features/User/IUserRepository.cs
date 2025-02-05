using Vanilla.Dtos.Common;
using Vanilla.Dtos.Requests.User;
using Vanilla.Dtos.Responses.User;
using X.PagedList;

namespace Vanilla.Application.Features.User;

public interface IUserRepository
{
    Task<GetAllUserResponseDto> GetAllAsync(PageMetadataDto request, CancellationToken cancellationToken);
    Task<UserDto> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<DeleteUserByIdResponseDto> DeleteByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<CreateUserResponseDto> InsertAsync(CreateUserRequestDto request, CancellationToken cancellationToken);
    Task<UpdateUserResponseDto> UpdateAsync(UpdateUserRequestDto request, CancellationToken cancellationToken); 
}