using AutoMapper;
using Domain.Entities;
using API.Dtos;

namespace ApiJwt.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
     { 
            CreateMap<Rol, RolDto>()
            .ReverseMap();

           

    }
}