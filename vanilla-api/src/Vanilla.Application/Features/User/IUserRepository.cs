// using Vanilla.Dtos.Common;
// using Vanilla.Dtos.Requests.User;
// using Vanilla.Dtos.Responses.User;
// using X.PagedList;
//
// namespace Vanilla.Application.Features.User;
//
// public interface IUserRepository
// {
//     Task<GetAllUserResponseDto> GetAllAsync(PageMetadataDto request);
//     Task<UserDto> GetByIdAsync(Guid id);
//     Task<DeleteUserByIdResponseDto> DeleteByIdAsync(Guid id);
//     Task<CreateUserResponseDto> CreateAsync(CreateUserRequestDto request);
//     Task<UpdateUserResponseDto> UpdateAsync(UpdateUserRequestDto request); 
// }