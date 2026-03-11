using AutoMapper;
using TrackFocus.Application.DTOs.Request;
using TrackFocus.Application.DTOs.Response;
using TrackFocus.Domain.Entities;

namespace TrackFocus.Application.Profiles.Security
{
    public class SerieProfile : Profile
    {
        public SerieProfile()
        {
            CreateMap<SerieRequest, Serie_Musculacao>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Exercicio, opt => opt.Ignore())
            .ForMember(dest => dest.ExercicioId, opt => opt.Ignore());
            CreateMap<Serie_Musculacao, SerieResponse>();
        }
    }
}