// using System.Transactions;
// using AutoMapper;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.ChangeTracking;
// using Vanilla.Application.Exceptions;
// using Vanilla.Domain.Entities;
// using Vanilla.Dtos.Common;
// using Vanilla.Dtos.Requests.User;
// using Vanilla.Dtos.Responses.User;
// using Vanilla.Persistence;
// using X.PagedList.EF;
//
// namespace Vanilla.Application.Features.User;
//
// public class UserRepository(IMapper mapper, VanillaDbContext context) : IUserRepository
// {
//     public async Task<GetAllUserResponseDto> GetAllAsync(PageMetadataDto request)
//     {
//         var users = await context.Users
//             .AsNoTracking() //read only
//             .ToPagedListAsync(request.CurrentPage, request.PageSize);
//         
//         return new GetAllUserResponseDto
//         {
//             Users = mapper.Map<List<UserDto>>(users),
//             PageMetadata = mapper.Map<PageDto>(users),
//         };
//     }
//
//     public Task<UserDto> GetByIdAsync(Guid id)
//     {
//         
//     }
//
//     public Task<DeleteUserByIdResponseDto> DeleteByIdAsync(Guid id)
//     {
//         throw new NotImplementedException();
//     }
//
//     public async Task<CreateUserResponseDto> CreateAsync(CreateUserRequestDto request)
//     {
//         if (await context.Users.AnyAsync(u => u.Email == request.Email))
//         {
//             throw new ConflictException($"{request.Email} is already taken.");
//         }
//
//         var mappedUser = mapper.Map<AppUser>(request);
//         await using var transaction = await context.Database.BeginTransactionAsync();
//         EntityEntry<AppUser> result;
//
//         try
//         {
//             result = await context.Users.AddAsync(mappedUser);
//             await context.SaveChangesAsync();
//             await transaction.CommitAsync();
//         }
//         catch (Exception exception)
//         {
//             await transaction.RollbackAsync();
//             throw new TransactionAbortedException(exception.Message);
//         }
//         
//         result.Entity
//     }
//
//     public Task<UpdateUserResponseDto> UpdateAsync(UpdateUserRequestDto request)
//     {
//         throw new NotImplementedException();
//     }
// }