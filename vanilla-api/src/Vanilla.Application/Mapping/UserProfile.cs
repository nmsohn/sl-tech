using AutoMapper;
using Vanilla.Domain.Entities;
using Vanilla.Dtos.Common;
using Vanilla.Dtos.Responses.User;
using X.PagedList;

namespace Vanilla.Application.Mapping;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<IPagedList, PageDto>();
    }
}