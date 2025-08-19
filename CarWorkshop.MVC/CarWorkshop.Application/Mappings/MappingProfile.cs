using AutoMapper;
using CarWorkshop.Application.ApplicationUser;
using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Application.CarWorkshop.Commands.EditCarWorkshop;
using CarWorkshop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile(IUserContext userContext)
        {
            var user = userContext.GetCurrentUser();

            CreateMap<CarWorkshopDto, Domain.Entities.CarWorkshop>()
                .ForMember(dest => dest.EncodedName, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore());

            CreateMap<ContactDetailsDto, CarWorkshopContactDetails>();

            CreateMap<Domain.Entities.CarWorkshop, CarWorkshopDto>()
                .ForMember(dest => dest.IsEditable,
                    opt => opt.MapFrom(src => user != null && src.CreatedById == user.Id));
            CreateMap<CarWorkshopContactDetails, ContactDetailsDto>();

            CreateMap<CarWorkshopDto, EditCarWorkshopCommand>();
        }
    }
}

