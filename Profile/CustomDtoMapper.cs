using Microsoft.AspNetCore.Identity;

namespace FinancialRevenues.Profile;

using Revenues.Entities;
using Users.Dtos;
using Users.Entities;
using Revenues.Dtos;

public class CustomDtoMapper : AutoMapper.Profile
{
    public CustomDtoMapper()
    {
        CreateMap<Revenue, CreateOrEditRevenueDto>().ReverseMap();
        CreateMap<Revenue, GetRevenueForViewDto>().ReverseMap();
        CreateMap<Revenue, GetRevenueForEditOutput>().ReverseMap();
        CreateMap<User, CreateOrEditUserDto>()
            .ForMember(dest => dest.RolesName,
                opt =>
                    opt.MapFrom(src =>
                        src.Roles.Select(r => r.Name)));
        CreateMap<User, GetUserForViewDto>().ReverseMap()
            .ForMember(e => e.FullName,
                e =>
                    e.MapFrom(x => x.FullName));
        CreateMap<UserDto, User>().ReverseMap();
    }
}