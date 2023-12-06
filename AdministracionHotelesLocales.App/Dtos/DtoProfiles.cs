using AdministracionHotelesLocales.Domain.Enums;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministracionHotelesLocales.App.Dtos
{
    public class DtoProfiles : Profile
    {
        public DtoProfiles()
        {
            CreateMap<HotelDto, Domain.Entities.Hotel>()
                .ForMember(dest => dest.Nombre,
                opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dest => dest.Id,
                opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Estrellas,
                opt => opt.MapFrom(src => src.Estrellas))
             .ReverseMap();

            CreateMap<HabitacionDto, Domain.Entities.Habitacion>()
                .ForMember(dest => dest.Tipo,
                opt => opt.MapFrom(src => src.Tipo))
             .ReverseMap();

            CreateMap<ReservaDto, Domain.Entities.Reserva>().ReverseMap();


        }
    }
}