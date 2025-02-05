using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Vanilla.Dtos.Common;
using Vanilla.Dtos.Requests.User;
using Vanilla.Dtos.Responses.User;
using Vanilla.Persistence;
using X.PagedList.EF;

namespace Vanilla.Application.Features.User;

public class UserRepository(IMapper mapper, VanillaDbContext context) : IUserRepository
{
    public async Task<GetAllUserResponseDto> GetAllAsync(PageMetadataDto request, CancellationToken cancellationToken)
    {
        var users = await context.Users
            .AsNoTracking() //read only
            .ToPagedListAsync(request.CurrentPage, request.PageSize);
        
        return new GetAllUserResponseDto
        {
            Users = mapper.Map<List<UserDto>>(users),
            PageMetadata = mapper.Map<PageDto>(users),
        };
    }

    public Task<UserDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<DeleteUserByIdResponseDto> DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<CreateUserResponseDto> InsertAsync(CreateUserRequestDto request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<UpdateUserResponseDto> UpdateAsync(UpdateUserRequestDto request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}